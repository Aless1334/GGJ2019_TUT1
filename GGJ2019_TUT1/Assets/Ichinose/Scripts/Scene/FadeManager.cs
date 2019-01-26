using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField, Header("移行シーン")]
    LoadScene scene;
    [SerializeField, Range(1.0f, 10.0f), Header("フェイド時間")]
    float fadeTime = 1.0f;
    [SerializeField, Range(1, 1000), Header("生成数（横）")]
    int xSize = 1;
    [SerializeField, Range(1, 1000), Header("生成数（縦）")]
    int ySize = 1;
    [SerializeField, Header("基本画像")]
    Image image;
    [SerializeField, Header("x軸Scale")]
    bool isScaleX = false;
    [SerializeField, Header("y軸Scale")]
    bool isScaleY = false;
    [SerializeField, Range(-360, 360), Header("回転角度")]
    float rotate = 0.0f;
    [SerializeField, Header("ランダムフェイド")]
    bool isRandom = true;

    [HideInInspector]
    public bool isTitle, isGamePlay;

    bool fadeIn, fadeOut, fadeEnd;
    bool isReLoad;
    float fadeTimer = 0.0f;
    Vector2 size;
    List<List<Image>> imageList;
    List<Image> randomList;

    // Use this for initialization
    void Start()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        size = new Vector2(screenSize.x / xSize, screenSize.y / ySize);

        if (image == null) return;
        imageList = new List<List<Image>>();
        for (int i = 0; i < xSize; i++)
        {
            imageList.Add(new List<Image>());
            for (int j = 0; j < ySize; j++)
            {
                imageList[i].Add(Instantiate(image, transform));

                imageList[i][j].rectTransform.sizeDelta = size;

                Vector2 pos = -screenSize / 2 + new Vector2(size.x * i, size.y * j);
                pos += size * imageList[i][j].rectTransform.pivot;
                imageList[i][j].rectTransform.localPosition = pos;
            }
        }

        SetRandom();

        fadeIn = false;
        fadeOut = false;
        fadeEnd = false;
        SetFadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetFadeEnd())
        {
            Load();
            return;
        }

        FadeIn();
        FadeOut();

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.Return))
            SetFadeOut();
#endif
    }

    void Load()
    {
        if (isReLoad) return;
        scene.Load();
    }

    void ReLoad()
    {
        if (!isReLoad) return;
        scene.ReLoad();
    }

    public void SetReLoad()
    {
        isReLoad = true;
    }

    void SetRandom()
    {
        if (!isRandom) return;

        List<Image> list = new List<Image>();

        for (int i = 0; i < imageList.Count; i++)
            for (int j = 0; j < imageList[i].Count; j++)
            {
                list.Add(imageList[i][j]);
            }

        for (int i = 0; i < imageList.Count; i++)
            for (int j = 0; j < imageList[i].Count; j++)
            {
                if (list.Count <= 0) break;
                int num = Random.Range(0, list.Count - 1);
                imageList[i][j] = list[num];
                list.RemoveAt(num);
            }
    }

    void FadeIn()
    {
        if (!(fadeIn && !fadeOut)) return;

        for (int i = 0; i < imageList.Count; i++)
        {
            imageList[i].RemoveAll(j => j == null);
        }

        imageList.RemoveAll(i => i.Count <= 0);

        fadeTimer += Time.deltaTime;
        fadeTimer = fadeTime < fadeTimer ? fadeTime : fadeTimer;
        float delete = fadeTimer / fadeTime;

        List<Image> list = new List<Image>();

        for (int i = 0; i < imageList.Count; i++)
            for (int j = 0; j < imageList[i].Count; j++)
            {
                list.Add(imageList[i][j]);
            }

        for (int i = 0; i < list.Count; i++)
        {
            Vector3 scale = list[i].rectTransform.localScale;
            float del = 1.0f - ((float)i + 1.0f) / (float)list.Count;
            if (del < 1.0f - delete) continue;
            if (scale.x <= 0 || scale.y <= 0) continue;
            if (isScaleX) scale.x -= delete;
            if (isScaleY) scale.y -= delete;
            if (!(isScaleX || isScaleY))
            {
                if (del >= 1.0f - delete)
                {
                    scale = Vector3.zero;
                }
            }
            scale.x = scale.x < 0 ? 0 : scale.x;
            scale.y = scale.y < 0 ? 0 : scale.y;
            scale = scale.x <= 0 || scale.y <= 0 ? Vector3.zero : scale;
            scale.z = 1;
            list[i].rectTransform.localScale = scale;
        }

        if (fadeTimer >= fadeTime)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].rectTransform.localScale = Vector3.zero;
            }
        }

        if (list.FindAll(i => i.rectTransform.localScale == Vector3.zero).Count == list.Count)
            fadeIn = false;
    }

    void FadeOut()
    {
        if (!(!fadeIn && fadeOut)) return;


        for (int i = 0; i < imageList.Count; i++)
        {
            imageList[i].RemoveAll(j => j == null);
        }

        imageList.RemoveAll(i => i.Count <= 0);

        fadeTimer -= Time.deltaTime;
        fadeTimer = 0 > fadeTimer ? 0 : fadeTimer;
        float plus = fadeTimer / fadeTime;

        List<Image> list = new List<Image>();

        for (int i = 0; i < imageList.Count; i++)
            for (int j = 0; j < imageList[i].Count; j++)
            {
                list.Add(imageList[i][j]);
            }

        for (int i = 0; i < list.Count; i++)
        {
            Vector3 scale = list[i].rectTransform.localScale;
            float pl = 1.0f - ((float)i + 1.0f) / (float)list.Count;
            if (pl < plus) continue;
            if (scale.x >= 1 || scale.y >= 1) continue;
            if (isScaleX) scale.x += 1 - plus;
            if (isScaleY) scale.y += 1 - plus;
            if (!(isScaleX || isScaleY))
            {
                if (pl >= plus)
                {
                    scale = Vector3.one;
                }
            }
            scale.x = scale.x > 1 ? 1 : scale.x;
            scale.y = scale.y > 1 ? 1 : scale.y;
            scale = scale.x >= 1 || scale.y >= 1 ? Vector3.one : scale;
            scale.z = 1;
            list[i].rectTransform.localScale = scale;
        }

        if (fadeTimer <= 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].rectTransform.localScale = Vector3.one;
            }
        }

        if (list.FindAll(i => i.rectTransform.localScale == Vector3.one).Count == list.Count)
        {
            fadeOut = false;
            fadeEnd = true;
        }
    }

    public void SetFadeIn()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public void SetFadeOut()
    {
        if (GetFade()) return;
        fadeIn = false;
        fadeOut = true;
    }

    public bool GetFadeIn()
    {
        return fadeIn && !fadeOut;
    }

    public bool GetFadeOut()
    {
        return !fadeIn && fadeOut;
    }

    public bool GetFade()
    {
        return fadeIn || fadeOut;
    }

    public bool GetFadeEnd()
    {
        return fadeEnd && !GetFade();
    }

    public void SetLoadScene(LoadScene scene)
    {
        this.scene = scene;
    }
}
