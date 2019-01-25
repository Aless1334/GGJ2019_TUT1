using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラを追従させるオブジェクトのタグ名
/// </summary>
public class ChaseCamera : MonoBehaviour
{
    [SerializeField, Header("追跡するタグ名設定(chaseTarget が NULL なら使用)")]
    TagName tagName = TagName.Player;
    [SerializeField, Header("追跡するオブジェクト(chaseTarget が NULL じゃなければ使用)")]
    GameObject chaseTarget;
    [SerializeField, Range(0.1f, 100.0f), Header("追跡速度(秒速)")]
    float chaseSpeed = 3;
    [SerializeField, Range(0.1f, 100.0f), Header("最大距離")]
    float chaseLength = 3.0f;

    GameObject target; //追跡するオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        ChaseTarget();
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

    /// <summary>
    /// ターゲットの追跡
    /// </summary>
    void ChaseTarget()
    {
        if (target == null) return;

        Vector2 pos = transform.position;
        Vector2 targetPos = target.transform.position;
        float length = Vector2.Distance(pos, targetPos);

        if (length > chaseLength)
        {
            Vector2 normalized = (pos - targetPos).normalized;
            pos = targetPos + normalized * chaseLength;
        }

        Vector2 lerp = Vector2.Lerp(pos, targetPos, chaseSpeed * Time.deltaTime);
        pos = lerp;
        transform.position = pos;

        SetPosZ();
    }

    /// <summary>
    /// Z軸設定
    /// </summary>
    /// <param name="z">Z軸</param>
    void SetPosZ(float z = -10)
    {
        Vector3 pos3 = transform.position;
        pos3.z = z;
        transform.position = pos3;
    }
}
