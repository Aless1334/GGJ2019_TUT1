using System.Collections;
using System.Collections.Generic;
using Nagasono.AudioScripts;
using UnityEngine;

public class ScoreItem : BaseItem
{
    [SerializeField] private int score;
    
    public override void Get()
    {
        Destroy(gameObject);
        GimmickScore.Instance.Add(score);
        AudioManager.PlayAudio("ItemPick");
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
