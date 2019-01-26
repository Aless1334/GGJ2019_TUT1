using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickScore
{
    private static GimmickScore score = null;
    private int scorePoint = 0;

    public static GimmickScore Instance
    {
        get {
            if (score == null) score = new GimmickScore();
            return score;
        }
        set { score = value; }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init() { Instance.scorePoint = 0; }

    /// <summary>
    /// ポイント加算
    /// </summary>
    /// <param name="point">追加ポイント</param>
    public void Add(int point = 0)
    {
        Instance.scorePoint += point;
    }

    public int GetPoint() { return Instance.scorePoint; }
}
