using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_ver3 : MonoBehaviour
{
    public Vector3 chaseTarget;
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D wall;
    [SerializeField] private bool isOnCollision;
    public float speed;
    public bool isChase;
    public float reach;
    //public Rigidbody2D rb;
    [SerializeField] private bool canGo;
    public float distance;
    public bool isMove;
    private bool isNowMove;

    // Start is called before the first frame update
    void Start()
    {
        isNowMove = isMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChase == true)
        {
            transform.position = Vector3.Lerp(transform.position, chaseTarget, speed);
        }
        IsMove();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RayShoot(0,1);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartChase()
    {
        StartCoroutine(ChaseAI());
    }

    private IEnumerator ChaseAI()
    {
        isChase = true;
        chaseTarget = player.transform.position;
        while (isOnCollision == false)
        {
            yield return null;
        }
        if (Mathf.Abs(transform.position.y - player.transform.position.y) < Mathf.Abs(transform.position.x - player.transform.position.x))
        {

            if (player.transform.position.y < transform.position.y)
            {
                canGo = RayTest(0, -1);
                if (canGo == true)
                {
                    chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                }
                else
                {
                    canGo = RayTest(0, 1);
                    if (canGo == true)
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                    }
                    else
                    {
                        canGo = RayTest(1, 0);
                        if (canGo == true)
                        {
                            chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
            else
            {

                canGo = RayTest(0, 1);
                if (canGo == true)
                {
                    chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                    //Destroy(ws0.gameObject);
                }
                else
                {
                    canGo = RayTest(0, -1);
                    if (canGo == true)
                    {
                        chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                        //Destroy(ws1.gameObject);
                    }
                    else
                    {
                        canGo = RayTest(1, 0);
                        if (canGo == true)
                        {
                            chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
        }
        else
        {
            if (player.transform.position.x < transform.position.x)
            {
                canGo = RayTest(-1, 0);
                if (canGo == true)
                {
                    chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                    //Destroy(ws0.gameObject);
                }
                else
                {
                    canGo = RayTest(1, 0);
                    if (canGo == true)
                    {
                        chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                        //Destroy(ws01.gameObject);
                    }
                    else
                    {
                        canGo = RayTest(0, 1);
                        if (canGo == true)
                        {
                            chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
            else
            {
                canGo = RayTest(1, 0);
                if (canGo == true)
                {
                    chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                    //Destroy(ws0.gameObject);
                }
                else
                {
                   canGo = RayTest(-1,0);
                    if (canGo == true)
                    {
                        chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                        //Destroy(ws01.gameObject);
                    }
                    else
                    {
                        canGo = RayTest(0, -1);
                        if (canGo == true)
                        {
                            chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
                        }
                        else
                        {
                            chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                        }
                        //Destroy(ws2.gameObject);
                    }
                }
            }
        }

        while (isOnCollision == true)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("Re");
        StartChase();
        yield break;

    }
    private void RayShoot(int x, int y)
    {
        Ray ray = new Ray(transform.position, new Vector3(x, y, 0));
        int distance = 10;
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.direction, Color.red,3f,false);
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log("false");
        }
    }
    private bool RayTest(int x, int y)
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = new Vector2(x, y);
        //Ray ray = new Ray(transform.position, direction);
        //new Vector3(transform.position.x * x, transform.position.y * y, transform.position.z));
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 0.32f);
        Debug.DrawRay(origin, direction * 0.32f, Color.blue, 3f, false);
        if (hit.collider)
        {
            Debug.Log(hit.collider.name);
            return false;
           
        }

        else
        {
            Debug.Log("RayTrue");
            return true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isOnCollision = true;
            wall = collision;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isOnCollision = false;
            //Invoke("AvoidReset", 1f);
            wall = null;
            Debug.Log("Exit");
        }

    }

    private void IsMove()
    {
        StartCoroutine(IsMove2());
    }

    private IEnumerator IsMove2()
    {
        Vector3 prePos = transform.position;
        //yield return new WaitForSeconds(0.2f);
        yield return null;
        if (Mathf.Abs(transform.position.y - prePos.y) < speed && (Mathf.Abs(transform.position.x - prePos.x) < speed))
        {
            prePos = transform.position;
            isMove = false;

        }
        else
        {
            isMove = true;
        }

    }
}
