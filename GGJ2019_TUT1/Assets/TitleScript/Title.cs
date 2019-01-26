using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Title : MonoBehaviour
{
    [SerializeField, Header("操作説明画面")]
    GameObject explane;

    [SerializeField] private AudioSource enterSE;
    FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        fadeManager = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeManager != null && fadeManager.GetFade()) return;
        if (explane == null || explane.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return) && fadeManager != null)
            {
                fadeManager.SetFadeOut();
                enterSE.Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return)) explane.SetActive(true);

    }
}
