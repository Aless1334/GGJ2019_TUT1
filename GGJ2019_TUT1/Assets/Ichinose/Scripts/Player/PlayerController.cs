using System.Collections;
using System.Collections.Generic;
using Nagasono.AudioScripts;
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

    private ItemType havingItem;
    public ItemType HavingItem
    {
        get { return havingItem; }
    }

    private bool isMoving;
    public bool Moving
    {
        get { return isMoving; }
    }

    private bool isDeath;

    // Start is called before the first frame update
    void Start()
    {
        isDeath = false;
        isMoving = false;
        havingItem = 0;
        velocity = Vector2.zero;
        var gimmicks = new List<ScoreItem>(FindObjectsOfType<ScoreItem>());
        int apple = gimmicks.FindAll(i => i.Type == ItemType.Apple).Count;
        GimmickScore.Instance.Init(apple);
        rigid = GetComponent<Rigidbody2D>();
        fadeManager = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetFlag();
        if (!isDeath) PlayerInput();
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

        isMoving = velocity.magnitude > 0.1f;
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
        isDeath = true;
        AudioManager.PlayAudio("EnemyHit");
        fadeManager.SetReLoad();
        fadeManager.SetFadeOut();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BaseItem item;
        if ((item = other.GetComponent<BaseItem>()) == null) return;

        havingItem |= item.Type;
        item.Get();
    }

    private void ResetFlag()
    {
        isMoving = false;
    }
}
