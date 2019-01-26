using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    private const float LimitMagnitude = 5f;

    [SerializeField] private GameObject lightMask;
    private Vector3 basePosition;
    public Vector3 moveVector { private get; set; }

    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        if((basePosition-transform.position).magnitude>LimitMagnitude)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other1)
    {
        Destroy(gameObject);
        var position = transform.position;
        Instantiate(lightMask, position, Quaternion.identity).GetComponent<LightMask>().ariveTime =
            (LimitMagnitude - (basePosition - position).magnitude);
    }
}
