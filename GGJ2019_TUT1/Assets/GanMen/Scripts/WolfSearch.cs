using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSearch : MonoBehaviour
{
    public bool isOnCol;
    // Start is called before the first frame update
    void Start()
    {
        isOnCol = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isOnCol = true;
        if (collision.tag == "wall")
        {
            
        }
    }
}
