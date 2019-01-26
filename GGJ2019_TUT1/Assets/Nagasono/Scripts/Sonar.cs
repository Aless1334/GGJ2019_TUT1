using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    private const float LimitMagnitude = 5f;
    private const float DelayLimit = 2f;

    [SerializeField] private GameObject lightMask;
    private Vector3 basePosition;
    public Vector3 moveVector { private get; set; }
    public float delaySpeed { private get; set; }

    private float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        delayTime = DelayLimit;
        basePosition = transform.position;
    }

    private void Update()
    {
        transform.position += moveVector * delayTime / (2f * delaySpeed) * Time.deltaTime;
        delayTime -= Time.deltaTime;
        if (delayTime < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other1)
    {
        if (other1.CompareTag("Player")) return;
        Destroy(gameObject);
        var position = transform.position;
        Instantiate(lightMask, position, Quaternion.identity).GetComponent<LightMask>().ariveTime =
            (LimitMagnitude - (basePosition - position).magnitude);
    }
}
