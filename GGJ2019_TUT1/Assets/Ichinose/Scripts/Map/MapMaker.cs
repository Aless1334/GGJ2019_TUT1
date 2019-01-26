using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// マップ生成
/// </summary>
public class MapMaker : MonoBehaviour
{
    [SerializeField, Header("読込むテキストファイル")]
    TextAsset textAsset;
    [SerializeField, Header("マップチップ設定")]
    List<MapChip> mapChipList;

    string[][] mapChip; //マップチップ

    /// <summary>
    /// マップ生成処理
    /// </summary>
    public void Make()
    {
        ReadText();
        DeleteChildren();
        InstanceChip();
    }

    /// <summary>
    /// テキスト読込
    /// </summary>
    void ReadText()
    {
        if (textAsset == null) return;
        StringReader reader = new StringReader(textAsset.text);
        List<string[]> txtList = new List<string[]>();
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            txtList.Add(line.Split(','));
        }

        mapChip = new string[txtList.Count][];
        for (int i = 0; i < txtList.Count; i++)
        {
            mapChip[i] = txtList[i];
        }
    }

    /// <summary>
    /// 子オブジェクト全削除
    /// </summary>
    void DeleteChildren()
    {
        if (mapChip == null) return;

        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    /// <summary>
    /// マップチップ追加
    /// </summary>
    void InstanceChip()
    {
        if (mapChip == null || mapChip.Length <= 0) return;
        float yLength = mapChip.Length;
        float xLength = mapChip[0].Length;

        for (int i = 0; i < mapChip.Length; i++)
        {
            for (int j = 0; j < mapChip[i].Length; j++)
            {
                int number;
                bool parsed = int.TryParse(mapChip[i][j], out number);
                if (!parsed) continue;

                var chip = mapChipList.Find(c => c.number == number);
                if (chip == null) continue;

                var obj = new GameObject();
                obj.name = chip.name;
                obj.transform.parent = transform;

                var sr = obj.AddComponent<SpriteRenderer>();
                sr.sprite = chip.sprite;

                Vector2 size = sr.size;
                obj.transform.position =
                    new Vector2( /*-xLength / 2*/ +j, /*yLength / 2*/ -i) * size;

                if (!chip.isCollision) continue;
                var col = Undo.AddComponent<BoxCollider2D>(obj);
                col.size = size;
            }
        }
    }

    /// <summary>
    /// リストの始めから順に番号を指定していく
    /// </summary>
    public void SetNumber()
    {
        for(int i=0;i<mapChipList.Count;i++)
        {
            mapChipList[i].number = i;
        }
    }
}
