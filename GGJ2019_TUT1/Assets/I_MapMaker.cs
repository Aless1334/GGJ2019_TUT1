using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// マップ生成
/// </summary>
public class I_MapMaker : MonoBehaviour
{
    private const float ItemPixel = 0.64f;

    [SerializeField, Header("読込むテキストファイル")]
    TextAsset textAsset;

    [SerializeField, Header("アイテムデータベース")] GameObject[] objectList;

    string[][] itemChip; //マップチップ

    /// <summary>
    /// マップ生成処理
    /// </summary>
    public void Make()
    {
        ReadText();
        if (itemChip == null) return;
        DeleteChildren();
        InstanceChip();
    }

    /// <summary>
    /// テキスト読込
    /// </summary>
    void ReadText()
    {
        if (textAsset == null)
        {
            return;
        }

        StringReader reader = new StringReader(textAsset.text);
        List<string[]> txtList = new List<string[]>();
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            txtList.Add(line.Split(','));
        }

        itemChip = new string[txtList.Count][];
        for (int i = 0; i < txtList.Count; i++)
        {
            itemChip[i] = txtList[i];
        }
    }

    /// <summary>
    /// 子オブジェクト全削除
    /// PrefabだとError
    /// </summary>
    public void DeleteChildren()
    {
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
        if (itemChip == null || itemChip.Length <= 0) return;
        float yLength = itemChip.Length;
        float xLength = itemChip[0].Length;

        for (int i = 0; i < itemChip.Length; i++)
        {
            for (int j = 0; j < itemChip[i].Length; j++)
            {
                int number;
                bool parsed = int.TryParse(itemChip[i][j], out number);
                if (!parsed) continue;

                if (number < 0 || number >= objectList.Length) continue;
                var chip = objectList[number];
                if (chip == null) continue;

                var obj = Instantiate(chip.gameObject, Vector2.zero, Quaternion.identity, transform);
                obj.name = chip.name;

                obj.transform.position =
                    new Vector2(j, -i) * ItemPixel;

                Undo.RegisterCreatedObjectUndo(obj, "Create IMap");
            }
        }
    }
}
