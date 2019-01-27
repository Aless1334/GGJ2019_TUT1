
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCut : MonoBehaviour
{
    private const float MoveDistance = 6.0f;
    private const float AnimTime = 4.0f;
    
    private Vector3 moveAmount;

    FadeManager fadeManager;

    private float beginTime;
    
    // Start is called before the first frame update
    void Start()
    {
        moveAmount = new Vector3(-MoveDistance / AnimTime, 0, 0);
        beginTime = Time.time;
        
        fadeManager = FindObjectOfType<FadeManager>();        
        Nagasono.AudioScripts.AudioManager.PlayAudio("CutRun");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveAmount * Time.deltaTime;
        if (Time.time - beginTime > AnimTime)
        {
            fadeManager.SceneLoad();
        }
    }
}