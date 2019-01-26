using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassMarker : MonoBehaviour
{   
    [SerializeField] private Goal goalObject;
    [SerializeField] private Transform baseTransform;

    // Update is called once per frame
    void Update()
    {
        if (goalObject == null) return;
        var direction = (goalObject.transform.position - baseTransform.position).normalized;
        var lookRotation = Quaternion.LookRotation(Vector3.back, direction);
        transform.localRotation = lookRotation;
    }
}
