using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoll : MonoBehaviour
{
    [SerializeField, Header("ポジション同期")]
    Transform synchro;

    // Update is called once per frame
    void Update()
    {
        Synchro();
    }

    void Synchro()
    {
        if (synchro == null) return;
        transform.position = synchro.position;
    }
}
