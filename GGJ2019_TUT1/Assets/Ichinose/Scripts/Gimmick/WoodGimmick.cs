using System;
using System.Collections;
using System.Collections.Generic;
using Nagasono.AudioScripts;
using UnityEngine;

public class WoodGimmick : BaseGimmick
{
    public GameObject AxEffect;

    public override void Init()
    {
        type = GimmickType.Wood;
    }

    public override void Action()
    {
    }

    public override void ItemAction(PlayerController player)
    {
        if (!player.HavingItem.HasFlag(ItemType.Ax)) return;
        AxEffect.SetActive(true);
        //Destroy(gameObject);
        Invoke("ObjDestroy", 0.5f);
        AudioManager.PlayAudio("Sword");
    }

    public void ObjDestroy()
    {
        //Destroy(AxEffect);
        Destroy(gameObject);
    }
}
