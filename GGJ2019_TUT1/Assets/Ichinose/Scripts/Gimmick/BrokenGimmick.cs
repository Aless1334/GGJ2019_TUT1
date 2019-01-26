using System;
using System.Collections;
using System.Collections.Generic;
using Nagasono.AudioScripts;
using UnityEngine;

public class BrokenGimmick : BaseGimmick
{
    [SerializeField, Range(0.0f, 100.0f), Header("アイテム使用後、以下の時間経過で壁破壊")]
    float breakTime = 3.0f;

    float breakingTime;
    bool isBreak;

    [SerializeField] private GameObject effect;

    public override void Action()
    {
        if (!isBreak) return;
        breakingTime += Time.deltaTime;
        if (breakingTime >= breakTime)
        {
            Destroy(gameObject);
        }
    }

    public override void Init()
    {
        breakingTime = 0.0f;
        isBreak = false;
    }

    public override void ItemAction(PlayerController player)
    {
        if (!player.HavingItem.HasFlag(ItemType.Wine)) return;
        effect.SetActive(true);
        AudioManager.PlayAudio("Wine");
        isBreak = true;
    }
}
