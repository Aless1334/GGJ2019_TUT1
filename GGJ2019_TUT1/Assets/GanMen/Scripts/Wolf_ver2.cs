using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_ver2 : MonoBehaviour
{
    public Vector3 chaseTarget;
    public GameObject player;
    private Collider2D wall;
    [SerializeField] private bool isOnCollision;
    public float speed;
    public bool isChase;
    //public Rigidbody2D rb;
    private bool canGo;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RayShoot(1, 0);
        }
        if (isChase == false)
        {
            transform.position = Vector3.Lerp(transform.position, chaseTarget, speed);
        }
    }

    public void StartChase()
    {
        StartCoroutine(ChaseAI());
    }

    private IEnumerator ChaseAI()
    {
        chaseTarget = player.transform.position;
        while (isOnCollision == false)
        {
            yield return null;
        }
        Debug.Log("y");
        if (Mathf.Abs(transform.position.y - wall.transform.position.y) < Mathf.Abs(transform.position.x - wall.transform.position.x))
        {
            if (player.transform.position.y < transform.position.y)
            {
                chaseTarget = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
            }
            else
            {
                chaseTarget = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
            }
        }
        else
        {
            if(player.transform.position.x < transform.position.x)
            {
                chaseTarget = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
            }
            else
            {
                chaseTarget = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
            }
        }
        
        while (isOnCollision == true)
        {
            yield return null;
        }
        Debug.Log("x");
        StartChase();


    }
    private void RayShoot(float x, float y)
    {
        Ray ray = new Ray(transform.position, new Vector3(x, y, 0));
        int distance = 10;
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log("false");


        }
    }
    private bool RayTest(float x, float y)
    {
        Ray ray = new Ray(transform.position, new Vector3(x, y, 0));
        //new Vector3(transform.position.x * x, transform.position.y * y, transform.position.z));
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log("false");
            return false;

        }

        else
        {
            return true;
        }
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
        wall = null;
    }

    private void PosChangeCheck()
    {

    }

}
