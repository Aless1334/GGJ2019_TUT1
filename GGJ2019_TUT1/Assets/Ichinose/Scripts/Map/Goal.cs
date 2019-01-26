using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField, Header("追跡するタグ名設定(chaseTarget が NULL なら使用)")]
    TagName tagName = TagName.Player;
    [SerializeField, Header("追跡するオブジェクト(chaseTarget が NULL じゃなければ使用)")]
    GameObject chaseTarget;

    GameObject target; //追跡するオブジェクト
    FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        SetTarget();
        fadeManager = FindObjectOfType<FadeManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != target) return;
        if (fadeManager == null) return;
        fadeManager.SetFadeOut();
    }

    /// <summary>
    /// ターゲット設定
    /// </summary>
    void SetTarget()
    {
        if (chaseTarget == null)
        {
            var objs = GameObject.FindGameObjectsWithTag(tagName.ToString());
            if (objs == null || objs.Length <= 0) return;
            target = objs[0];
            return;
        }
        target = chaseTarget;
    }
}
