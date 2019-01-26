using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : BaseItem
{
    public override void Get()
    {
        Debug.Log("Get Item");
        Destroy(gameObject);
    }

    public override void Use()
    {
        Debug.Log("Use Item");
    }
}
