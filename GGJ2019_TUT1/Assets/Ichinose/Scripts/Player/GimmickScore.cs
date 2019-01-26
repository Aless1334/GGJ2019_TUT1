using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GimmickScore
{
    private static GimmickScore score = null;
    private int scorePoint = 0;
    private Dictionary<string, int> scenePoint;

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

    /// <summary>
    /// スコア取得
    /// </summary>
    /// <returns>スコア</returns>
    public int GetPoint() { return Instance.scorePoint; }

    /// <summary>
    /// 各シーンのポイントを保存
    /// ゲームクリア時に使用
    /// </summary>
    public void ScenePoint()
    {
        string name = SceneManager.GetActiveScene().name;
        if (Instance.scenePoint == null)
        {
            Instance.scenePoint = new Dictionary<string, int>();
        }

        if (Instance.scenePoint.ContainsKey(name))
        {
            Instance.scenePoint[name] = GetPoint();
        }
        else
        {
            Instance.scenePoint.Add(name, GetPoint());
        }
    }

    /// <summary>
    /// すべてのシーンのポイントを取得
    /// </summary>
    /// <returns>全てのポイント</returns>
    public int AllScenePoint()
    {
        int point = 0;
        foreach(var i in scenePoint)
        {
            point = i.Value;
        }
        return point;
    }
}
