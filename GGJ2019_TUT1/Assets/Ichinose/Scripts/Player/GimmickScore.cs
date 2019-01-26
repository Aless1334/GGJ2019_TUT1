using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GimmickScore
{
    private static GimmickScore score = null;
    private int scorePoint = 0;
    private int maxPoint = 0;
    private Dictionary<string, int> scenePoint;
    private Dictionary<string, int> sceneMax;

    public static GimmickScore Instance
    {
        get
        {
            if (score == null) score = new GimmickScore();
            return score;
        }
        set { score = value; }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init(int max = 0)
    {
        Instance.scorePoint = 0;
        Instance.maxPoint = max;
    }

    /// <summary>
    /// ポイント加算
    /// </summary>
    /// <param name="point">追加ポイント</param>
    public void Add(int point = 0)
    {
        Instance.scorePoint += point;
    }

    /// <summary>
    /// スコア取得
    /// </summary>
    /// <returns>スコア</returns>
    public int GetPoint() { return Instance.scorePoint; }

    /// <summary>
    /// マックス取得
    /// </summary>
    /// <returns>マックス</returns>
    public int GetMax() { return Instance.maxPoint; }

    /// <summary>
    /// 各シーンのポイントを保存
    /// ゲームクリア時に使用
    /// </summary>
    public void SetPoint()
    {
        string name = SceneManager.GetActiveScene().name;
        if (Instance.scenePoint == null)
        {
            Instance.scenePoint = new Dictionary<string, int>();
            Instance.sceneMax = new Dictionary<string, int>();
        }

        if (Instance.scenePoint.ContainsKey(name))
        {
            Instance.scenePoint[name] = GetPoint();
            Instance.sceneMax[name] = GetMax();
        }
        else
        {
            Instance.scenePoint.Add(name, GetPoint());
            Instance.sceneMax.Add(name, GetMax());
        }
    }

    /// <summary>
    /// すべてのシーンのポイントを取得
    /// </summary>
    /// <returns>全てのポイント</returns>
    public int AllScenePoint()
    {
        int point = 0;
        foreach (var i in scenePoint)
        {
            point = i.Value;
        }
        return point;
    }

    /// <summary>
    /// すべてのシーンのマックス値を取得
    /// </summary>
    /// <returns>全てのマックス値</returns>
    public int AllSceneMax()
    {
        int max = 0;
        foreach (var i in sceneMax)
        {
            max = i.Value;
        }
        return max;
    }

    public float Result()
    {
        float result = (float)AllScenePoint() / (float)AllSceneMax() * 100.0f;
        return result;
    }
}
