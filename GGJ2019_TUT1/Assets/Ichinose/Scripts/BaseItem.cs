using System;
using UnityEngine;

/// <summary>
/// アイテム親クラス
/// </summary>
public abstract class BaseItem : MonoBehaviour
{
    //アイテム名
    protected string name = "item";
    
    [SerializeField] protected ItemType type;
    public ItemType Type
    {
        get { return type; }
    }

    /// <summary>
    /// 入手時処理
    /// </summary>
    public abstract void Get();

    /// <summary>
    /// 使用時処理
    /// </summary>
    public abstract void Use();
}

/// <summary>
/// アイテムの種類
/// </summary>
[Flags]
public enum ItemType
{
    /// <summary>
    /// 斧
    /// </summary>
    Ax = 1,

    /// <summary>
    /// リンゴ
    /// </summary>
    Apple = 1 << 1,

    /// <summary>
    /// ワイン
    /// </summary>
    Wine = 1 << 2
}