using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRun : MonoBehaviour
{
    [SerializeField, Range(0, 100), Header("速度")]
    float speed = 5.0f;

    [SerializeField, Header("フィールドチップ")]
    GameObject fieldPrefab;
    [SerializeField, Range(0, 100), Header("チップ数（横）")]
    int fieldXCount = 30;
    List<GameObject> fieldList;
    Vector2 fieldSize;

    [SerializeField, Header("プレイヤー")]
    GameObject playerPrefab;
    GameObject player;
    float playerPercent = 1.0f;

    [SerializeField, Header("木")]
    GameObject woodPrefab;
    GameObject wood;
    List<GameObject> woodList;
    [SerializeField, Range(0.0f, 100.0f), Header("木生成確率")]
    float woodPop = 1.0f;

    float roadLength;
    bool isNext, isEnd;

    FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        fadeManager = FindObjectOfType<FadeManager>();
        SetField();
        SetPlayer();
        SetWood();
    }

    // Update is called once per frame
    void Update()
    {
        MoveField();
        MovePlayer();
        PopWood();
        MoveWood();
    }

    void SetField()
    {
        fieldList = new List<GameObject>();
        if (fieldPrefab == null) return;
        fieldSize = Vector2.one;
        var sr = fieldPrefab.GetComponent<SpriteRenderer>();
        if (sr != null) fieldSize = sr.size;

        for (int i = 0; i < fieldXCount; i++)
        {
            fieldList.Add(Instantiate(fieldPrefab, transform));
        }

        for (int i = 0; i < fieldList.Count; i++)
        {
            var pos = fieldList[i].transform.position;
            pos.x = (-fieldList.Count / 2 + i) * fieldSize.x;
            fieldList[i].transform.position = pos;
        }

        roadLength = fieldList.Count * fieldSize.x;
    }

    void MoveField()
    {
        fieldList.Sort((a, b) => -(int)((a.transform.position.x - b.transform.position.x) * 100));

        for (int i = 0; i < fieldList.Count; i++)
        {
            var pos = fieldList[i].transform.position;
            pos.x += Time.deltaTime * speed;
            fieldList[i].transform.position = pos;
        }

        if (fieldList[0].transform.position.x >= fieldList.Count * fieldSize.x / 2)
        {
            var mov = fieldList[0].transform.position;
            mov.x -= fieldList.Count * fieldSize.x;
            fieldList[0].transform.position = mov;
        }
    }

    void SetPlayer()
    {
        if (playerPrefab == null) return;
        player = Instantiate(playerPrefab, transform);
        player.transform.position = new Vector2(roadLength / 2, -fieldSize.x * 4f);
    }

    void MovePlayer()
    {
        if (fadeManager != null && fadeManager.GetFadeIn()) return;
        if (isEnd) return;

        if (!isNext && playerPercent > 0)
        {
            playerPercent -= Time.deltaTime / speed;
            if (playerPercent <= 0) playerPercent = 0;
            var pos = player.transform.position;
            float cos = Mathf.Cos(90 * playerPercent / 180 * Mathf.PI);
            pos.x = (1 - cos) * fieldList.Count / 2 * fieldSize.x;
            player.transform.position = pos;
        }
        else if (isNext && playerPercent > -1.0f)
        {
            playerPercent -= Time.deltaTime / speed;
            if (playerPercent <= -1.0f) playerPercent = -1.0f;
            var pos = player.transform.position;
            float cos = -Mathf.Cos((1 + playerPercent) * 90 / 180 * Mathf.PI);
            pos.x = (cos) * fieldList.Count / 2 * fieldSize.x;
            player.transform.position = pos;
        }

        if (playerPercent <= -1.0f) isEnd = true;
    }

    void SetWood()
    {
        if (woodPrefab == null) return;
        woodList = new List<GameObject>();
    }

    void PopWood()
    {
        if (woodList == null) return;
        if (woodPop >= Random.Range(0.0f, 100.0f))
        {
            int rnd = (int)Random.Range(0, 10);
            rnd = rnd < 5 ? 1 : 3;
            var w = Instantiate(woodPrefab, transform);
            w.transform.position =
                new Vector2(-fieldList.Count / 1.5f * fieldSize.x, -fieldSize.y * rnd / 3);

            foreach (Transform i in w.transform)
            {
                var sr = i.GetComponent<SpriteRenderer>();
                if (sr != null) sr.sortingOrder = 3 + rnd;
            }
            woodList.Add(w);
        }
    }

    void MoveWood()
    {
        if (woodList == null) return;
        foreach (var i in woodList)
        {
            if (i == null) continue;
            var pos = i.transform.position;
            pos.x += Time.deltaTime * speed;
            i.transform.position = pos;
        }

        var list = woodList.FindAll(i => i != null && i.transform.position.x >= fieldList.Count * fieldSize.x);

        list.ForEach(i => Destroy(i.gameObject));
        woodList.RemoveAll(i => i == null || i.transform.position.x >= fieldList.Count * fieldSize.x);
    }

    public bool GetAgree() { return playerPercent == 0; }
    public void SetIsNext() { isNext = true; }
    public bool GetIsEnd() { return isEnd; }
}
