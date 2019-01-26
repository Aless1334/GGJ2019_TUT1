using System;
using System.Collections;
using System.Collections.Generic;
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

    public override void ItemAction()
    {
        Destroy(gameObject);
    }
}
