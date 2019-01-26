using System;
using System.Collections;
using System.Collections.Generic;
using Nagasono.AudioScripts;
using UnityEngine;

public class WoodGimmick : BaseGimmick
{

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
            Destroy(gameObject);
            AudioManager.PlayAudio("Sword");
    }
}
