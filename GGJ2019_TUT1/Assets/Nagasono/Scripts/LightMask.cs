using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMask : MonoBehaviour
{
    public float ariveTime { private get; set; }

    // Update is called once per frame
    void Update()
    {
        ariveTime -= Time.deltaTime;
        if (ariveTime < 0)
            Destroy(gameObject);
    }
}
