using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppEscape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            Application.Quit();
        else
            SceneManager.LoadScene(0);
    }
}
