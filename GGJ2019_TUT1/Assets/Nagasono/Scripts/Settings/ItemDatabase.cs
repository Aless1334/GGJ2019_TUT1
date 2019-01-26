using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/Item", fileName = "New ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private BaseItem[] items;

    public BaseItem[] Items
    {
        get { return items; }
    }
}
