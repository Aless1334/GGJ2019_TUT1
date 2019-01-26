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
    private bool isChase;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isChase == true)
        {
            transform.position = Vector3.Lerp(transform.position, chaseTarget, speed);
        }
    }

    public void StartChase()
    {

    }

}
