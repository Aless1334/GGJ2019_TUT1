using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Title : MonoBehaviour
{
    [SerializeField, Header("操作説明画面")]
    GameObject explane;

    [SerializeField]
    private AudioSource enterSE;
    FadeManager fadeManager;
    TitleRun titleRun;

    // Start is called before the first frame update
    void Start()
    {
        fadeManager = FindObjectOfType<FadeManager>();
        titleRun = GetComponent<TitleRun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeManager != null && (fadeManager.GetFade() || fadeManager.GetFadeEnd())) return;

        if (titleRun == null || titleRun.GetAgree())
            if (Input.GetKeyDown(KeyCode.Space)) explane.SetActive(!explane.activeInHierarchy);

        if (explane.activeInHierarchy) return;

        if (Input.GetKeyDown(KeyCode.Return) && fadeManager != null)
        {
            if (titleRun == null)
            {
                fadeManager.SetFadeOut();
                enterSE.Play();
            }
            else if(titleRun.GetAgree())
            {
                titleRun.SetIsNext();
            }
        }

        if (titleRun != null && titleRun.GetIsEnd())
        {
            fadeManager.SetFadeOut();
            enterSE.Play();
        }
    }
}
