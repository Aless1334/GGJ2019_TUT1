using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム親クラス
/// </summary>
public class BaseItem : MonoBehaviour
{
    //アイテム名
    protected string name = "item";

    /// <summary>
    /// 入手時処理
    /// </summary>
    public virtual void Get() { }

    /// <summary>
    /// 使用時処理
    /// </summary>
    public virtual void Use() { }
}

/// <summary>
/// アイテムの種類
/// </summary>
public enum ItemType
{
    /// <summary>
    /// 斧
    /// </summary>
    ax, 
    /// <summary>
    /// リンゴ
    /// </summary>
    apple, 
}