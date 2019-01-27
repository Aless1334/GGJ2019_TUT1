using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    [SerializeField, Header("木の背景")]
    GameObject woods;
    [SerializeField, Header("地面")]
    GameObject ground;

    [SerializeField, Range(0, 100), Header("速度")]
    float speed = 3.0f;

    Text myText;
    float woodsMoveY;
    bool isEnd;
    FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        SetResult();
        SetWoods();
        fadeManager = FindObjectOfType<FadeManager>();
    }

    private void SetResult()
    {
        float result = GimmickScore.Instance.Result();
        myText = GetComponentInChildren<Text>();
        myText.text = "Score : " + result + "%";
        SetAlpha(0);
    }

    private void SetWoods()
    {
        if (woods == null) return;
        float maxY = 1, minY = -1;
        int wCount = 0;
        List<SpriteRenderer> woodList = new List<SpriteRenderer>();
        foreach (Transform i in woods.transform)
            foreach (Transform j in i)
            {
                minY = j.position.y < minY ? j.position.y : minY;
                maxY = j.position.y > maxY ? j.position.y : maxY;

                wCount = 0;
                foreach (Transform w in j)
                {
                    foreach (Transform s in w)
                    {
                        var sr = s.GetComponent<SpriteRenderer>();
                        if (sr != null) woodList.Add(sr);
                        wCount++;
                    }
                }
            }

        for (int i = 0; i < woodList.Count; i++)
        {
            int s = (int)(i / 4) % 2 == 0 ? 0 : 1;
            int y = i / wCount;
            woodList[i].sortingOrder = 10 + s + y * 10;
        }

        woodsMoveY = maxY + Mathf.Abs(minY);
        woodsMoveY *= 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        WoodsMove();
        MoveGround();
        AddAlpha();
        FadeOut();
    }

    void WoodsMove()
    {
        if (woods == null || isEnd) return;
        var pos = woods.transform.position;
        pos.y -= Time.deltaTime * speed;
        woods.transform.position = pos;
        if (pos.y <= -woodsMoveY * 1.2f) isEnd = true;
    }

    void MoveGround()
    {
        if (ground == null) return;
        ground.transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    void FadeOut()
    {
        if (!isEnd) return;
        if (fadeManager == null || fadeManager.GetFadeEnd() || fadeManager.GetFade()) return;
        if (myText.color.a < 1.0f) return;
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            fadeManager.SetFadeOut();
        }
    }

    void AddAlpha()
    {
        float alpha = myText.color.a;
        if (!isEnd || alpha >= 1.0f) return;
        alpha += Time.deltaTime;
        alpha = alpha > 1 ? 1 : alpha;
        SetAlpha(alpha);
    }

    void SetAlpha(float alpha = 1.0f)
    {
        Color color = myText.color;
        color.a = alpha;
        myText.color = color;
    }
}
