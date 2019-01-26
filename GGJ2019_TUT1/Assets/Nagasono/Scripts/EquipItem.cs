using System.Collections;
using System.Collections.Generic;
using Nagasono.AudioScripts;
using UnityEngine;

public class EquipItem : BaseItem
{
    public override void Get()
    {
        Destroy(gameObject);
        AudioManager.PlayAudio("ItemPick");
    }

    public override void Use()
    {
        Debug.Log("Use Item");
    }
}
