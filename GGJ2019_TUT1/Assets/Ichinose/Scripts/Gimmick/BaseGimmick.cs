using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGimmick : MonoBehaviour
{
    protected GimmickType type;

    [SerializeField] protected SpriteMask objectMask;
    private float restLightTime;

    void Start()
    {
        objectMask.gameObject.SetActive(false);
        Init();
        restLightTime = -1;
    }

    void Update()
    {
        if (restLightTime >= 0)
        {
            restLightTime -= Time.deltaTime;
            if (restLightTime < 0)
            {
                objectMask.gameObject.SetActive(false);
            }
        }

        Action();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 処理
    /// </summary>
    public abstract void Action();

    /// <summary>
    /// アイテム時処理
    /// </summary>
    public abstract void ItemAction(PlayerController player);

    public void LightUp(float time)
    {
        objectMask.gameObject.SetActive(true);
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player;
        if ((player = other.gameObject.GetComponent<PlayerController>()) == null) return;
        ItemAction(player);
    }
}

public enum GimmickType
{
    /// <summary>
    /// 倒木
    /// </summary>
    Wood,
}