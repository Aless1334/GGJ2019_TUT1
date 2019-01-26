using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayDestroy", 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DelayDestroy ()
    {
        Destroy(gameObject);
    }
}
