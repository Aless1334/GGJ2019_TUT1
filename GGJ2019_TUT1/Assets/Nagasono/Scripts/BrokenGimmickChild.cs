using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGimmickChild : MonoBehaviour
{
    private BrokenGimmick broken;

    // Start is called before the first frame update
    void Start()
    {
        broken = transform.parent.GetComponent<BrokenGimmick>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player;
        if ((player = other.gameObject.GetComponent<PlayerController>()) == null) return;
        broken.ItemAction(player);
    }
}
