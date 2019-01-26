using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー処理
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0.0f, 100.0f), Header("速度")]
    float playerSpeed = 5.0f;

    Vector2 velocity; //速度
    Rigidbody2D rigid;
    FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        GimmickScore.Instance.Init();
        rigid = GetComponent<Rigidbody2D>();
        fadeManager = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        //PlayerMove();
    }

    /// <summary>
    /// プレイヤーの入力
    /// </summary>
    void PlayerInput()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        velocity = new Vector2(inputX, inputY) * playerSpeed;
        rigid.velocity = velocity;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void PlayerMove()
    {
        Vector2 playerPosition = transform.position;
        playerPosition += velocity * playerSpeed * Time.deltaTime;
        transform.position = playerPosition;
    }

    public void Dead()
    {
        if (fadeManager == null) return;
        fadeManager.SetReLoad();
        fadeManager.SetFadeOut();
    }
}
