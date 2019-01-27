using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nagasono.AudioScripts;

public class WolfCtrl : MonoBehaviour
{
    [SerializeField] private Wolf_ver3 wolf;
    public float chaseLimitDistance;
    // Start is called before the first frame update

    private void Awake()
    {
        wolf = GetComponent<Wolf_ver3>();
    }
    void Start()
    {
        
        wolf.isChase = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ChaseCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Sonar"&&wolf.isChase==false)
        {
            AudioManager.PlayAudio("Enemy");
            wolf.StartChase();
        }

        if(collision.gameObject.tag == "Player")
        {
            AudioManager.PlayAudio("EnemyHit");
            collision.GetComponent<PlayerController>().Dead();
        }
    }

    private void ChaseCheck()
    {
        if(Mathf.Abs(wolf.player.transform.position.x - transform.transform.position.x) >= chaseLimitDistance 
            || Mathf.Abs(wolf.player.transform.position.y - transform.transform.position.y) >= chaseLimitDistance)
        {
            wolf.isChase = false;
        }
    }
}
