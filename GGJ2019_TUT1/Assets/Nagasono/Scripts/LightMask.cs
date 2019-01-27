using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMask : MonoBehaviour
{
    public float ariveTime { private get; set; }

    private void OnEnable()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x / 2.0f);

        Wolf_ver3 wolf;
        foreach (var collider1 in colliders)
        {
            if ((wolf = collider1.GetComponent<Wolf_ver3>()) == null) continue;
            wolf.StartChase();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ariveTime -= Time.deltaTime;
        if (ariveTime < 0)
            gameObject.SetActive(false);
    }
}
