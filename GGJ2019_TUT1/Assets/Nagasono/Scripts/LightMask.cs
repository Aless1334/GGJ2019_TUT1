using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMask : MonoBehaviour
{
    [SerializeField] private float originSize;

    public float LimitTime { private get; set; }
    private float acceptTime;

    private void OnEnable()
    {
        acceptTime = 0;

        transform.localScale = new Vector3(originSize, originSize, 1);

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
        acceptTime += Time.deltaTime;
        var scale = (LimitTime - acceptTime*0.6f) / LimitTime * 1.0f * originSize;
        transform.localScale = new Vector3(scale, scale, 1);

        if (acceptTime >= LimitTime)
            gameObject.SetActive(false);
    }
}
