using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LoadScene
{

    [SerializeField]
    SceneObject sceneObject;

    public void Load()
    {
        if (!GetScene())
        {
            Debug.Log(sceneObject.ToString() + " >> ロード先が設定されていません。自身を読み込みます。");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        SceneManager.LoadScene(sceneObject.ToString());
    }

    public void ReLoad()
    {
        return;
    }

    /// <summary>
    /// シーンがあるか否か
    /// </summary>
    /// <returns>あったらTRUE なければFALSE</returns>
    bool GetScene()
    {
        if (sceneObject == null) return false;
        if (sceneObject.ToString() == "") return false;

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string name = SceneUtility.GetScenePathByBuildIndex(i);
            if (name == "") continue;
            string[] names = name.Split('/');
            if (name.Contains(sceneObject.ToString())) return true;
        }
        return false;
    }

    public void SetScene(SceneObject scene)
    {
        sceneObject = scene;
    }

    public override string ToString()
    {
        return sceneObject.ToString();
    }
}
