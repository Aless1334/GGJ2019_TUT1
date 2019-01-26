using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField, Header("プレイヤーのアニメーション")]
    Animator playerAnim;

    [SerializeField, Header("前向き")]
    PlayerAnimType front;
    [SerializeField, Header("左向き")]
    PlayerAnimType left;
    [SerializeField, Header("右向き")]
    PlayerAnimType right;
    [SerializeField, Header("後向き")]
    PlayerAnimType back;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim(GetAngle());
    }

    /// <summary>
    /// 角度によるアニメーション処理
    /// </summary>
    /// <param name="deg">弧度法</param>
    void Anim(float deg)
    {
        Vector2 vel = rigid.velocity;
        if (vel.magnitude <= 0.0f) return;
            if (deg < 45 && deg > -45) playerAnim.Play(right.ToString());
        if (deg < -135 || deg > 135) playerAnim.Play(left.ToString());
        if (deg <= 135&& deg >= 45) playerAnim.Play(back.ToString());
        if (deg <= -45 && deg >= -135) playerAnim.Play(front.ToString());
    }

    /// <summary>
    /// 角度
    /// </summary>
    /// <returns>度数法</returns>
    float GetAngle()
    {
        Vector2 vel = rigid.velocity;
        if (vel.magnitude <= 0.0f)
        {
            StayAnim();
            return 0;
        }
        var rad = Mathf.Atan2(vel.y, vel.x);
        return rad * Mathf.Rad2Deg;
    }

    void StayAnim()
    {
        var stateInfo = playerAnim.GetCurrentAnimatorStateInfo(0);
        var animationHash = stateInfo.shortNameHash;

        playerAnim.Play(animationHash, 0, 0);
    }
}

[System.Serializable]
public class PlayerAnimType
{
    public AnimationClip clip;
    public override string ToString()
    {
        return clip == null ? "" : clip.name;
    }
}