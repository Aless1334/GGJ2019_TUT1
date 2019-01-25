using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapChip
{
    [Header("マップチップ名")]
    public string name = "MapChip";
    [Header("使用番号（重複の場合は先にあるものを使用）")]
    public int number = 0;
    [Header("使用画像")]
    public Sprite sprite;
    [Header("コライダいれるか(BoxCollider2D)")]
    public bool isCollision;
}
