using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnm : MonoBehaviour
{
    private const int ChaseOrder = 6;
    private const int StayOrder = 1;

    private Animator anmWolf;
    private Wolf_ver3 wolf;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        anmWolf = GetComponent<Animator>();
        wolf = GetComponent<Wolf_ver3>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (wolf.isChase)
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
  
                anmWolf.SetBool("IsBack", true);
                anmWolf.SetBool("IsFront", false); anmWolf.SetBool("IsLeft", false); anmWolf.SetBool("IsRight", false);
            }
            else
            {
                anmWolf.SetBool("IsFront", true);
                anmWolf.SetBool("IsBack", false); anmWolf.SetBool("IsLeft", false); anmWolf.SetBool("IsRight", false);
            }
        }
        else
        {
            if (wolf.chaseTarget.x >= wolf.transform.position.x)
            {
                anmWolf.SetBool("IsRight", true);
                anmWolf.SetBool("IsFront", false); anmWolf.SetBool("IsLeft", false); anmWolf.SetBool("IsBack", false);
            }
            else
            {
                anmWolf.SetBool("IsLeft", true);
                anmWolf.SetBool("IsFront", false); anmWolf.SetBool("IsBack", false); anmWolf.SetBool("IsRight", false);
            }
        }
    }
}
