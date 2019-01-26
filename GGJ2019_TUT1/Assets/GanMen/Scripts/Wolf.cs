using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
    public Vector3 chaseTarget;
    public GameObject player;
    private Collider2D wall;
    [SerializeField] private bool isOnCollision;
    public float speed;
    private bool isChase;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        isOnCollision = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChase == false)
        {
            Chase();
            Avoid();
        }
        
    }

    public void StartChase()
    {
        chaseTarget = player.transform.position;

    }

    private void Avoid()
    {
        /*if(isOnCollision == true)
        {
            if (Mathf.Abs(transform.position.x - wall.transform.position.x) > 1.28f || Mathf.Abs(transform.position.y - wall.transform.position.y) > 1.28f)
            {
                if (player.transform.position.x < wall.transform.position.x)
                {
                    if (player.transform.position.y < wall.transform.position.y)
                    {
                        chaseTarget = new Vector3(wall.transform.position.x + 0.32f, wall.transform.position.y + 0.32f);
                    }
                    else
                    {
                        chaseTarget = new Vector3(wall.transform.position.x + 0.32f, wall.transform.position.y - 0.32f);
                    }
                }
                else
                {
                    if (player.transform.position.y < wall.transform.position.y)
                    {
                        chaseTarget = new Vector3(wall.transform.position.x - 0.32f, wall.transform.position.y + 0.32f);
                    }
                    else
                    {
                        chaseTarget = new Vector3(wall.transform.position.x - 0.32f, wall.transform.position.y - 0.32f);
                    }
                }
            }
        }

        else
        {
            chaseTarget = player.transform.position;
        }*/



        if (isOnCollision == true)
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 0.64f || Mathf.Abs(transform.position.y - player.transform.position.y) <= 0.64f)
            {
                if (Mathf.Abs(transform.position.x - player.transform.position.x) < Mathf.Abs(transform.position.y - player.transform.position.y))
                {
                    if (transform.position.x > player.transform.position.x)
                    {
                        chaseTarget = new Vector3(transform.position.x - 1.6f, transform.position.y);
                    }
                    else
                    {
                        chaseTarget = new Vector3(transform.position.x + 1.6f, transform.position.y);
                    }

                }
                else
                {
                    if (transform.position.y > player.transform.position.y)
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y - 1.6f);
                    }
                    else
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y + 1.6f);
                    }
                }
            }

            else
            {
                if (transform.position.x > player.transform.position.x)
                {
                    if (transform.position.y > player.transform.position.y)
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y - 1.6f);
                    }
                    else
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y + 1.6f);
                    }

                }
                else
                {
                    if (transform.position.y > player.transform.position.y)
                    {
                        chaseTarget = new Vector3(transform.position.x - 1.6f, transform.position.y);
                    }
                    else
                    {
                        chaseTarget = new Vector3(transform.position.x + 1.6f, transform.position.y);
                    }

                }
            }

        }
        else
        {
            chaseTarget = player.transform.position;
        }
    }


    private void Chase()
    {
        transform.position = Vector3.Lerp(transform.position, chaseTarget, speed);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isOnCollision = true;
        wall = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        isOnCollision = false;
        //Invoke("AvoidReset", 1f);
        Debug.Log("Exit");
        wall = null;
    }

    private void AvoidReset()
    {
        chaseTarget = player.transform.position;
    }
}
