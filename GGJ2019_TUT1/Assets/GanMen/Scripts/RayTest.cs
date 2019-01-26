using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = transform.position.x + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RayShoot(x, y);
        }
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
}
