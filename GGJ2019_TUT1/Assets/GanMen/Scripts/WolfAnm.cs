using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnm : MonoBehaviour
{
    private const int ChaseOrder = 6;
    private const int StayOrder = 1;

    public Wolf_ver3 wolf;
    public Sprite s0, s1, s3, s4;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        wolf = GetComponent<Wolf_ver3>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wolf.isMove)
        {
            AnmCtrl();
            spriteRenderer.sortingOrder = ChaseOrder;
        }
        else
        {
            spriteRenderer.sortingOrder = StayOrder;
        }
    }

    void AnmCtrl()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (Mathf.Abs(wolf.chaseTarget.y - wolf.transform.position.y) >
            Mathf.Abs(wolf.chaseTarget.x - wolf.transform.position.x))
        {
            if (wolf.chaseTarget.y >= wolf.transform.position.y)
            {
                sprite.sprite = s1;
            }
            else
            {
                sprite.sprite = s0;
            }
        }
        else
        {
            if (wolf.chaseTarget.x >= wolf.transform.position.x)
            {
                sprite.sprite = s4;
            }
            else
            {
                sprite.sprite = s3;
            }
        }
    }
}
