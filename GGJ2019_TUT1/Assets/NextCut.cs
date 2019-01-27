
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCut : MonoBehaviour
{
    private Vector3 eye_Player;

    FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {

        fadeManager = FindObjectOfType<FadeManager>();        
        eye_Player = GameObject.Find("Main Camera").transform.position;
        eye_Player.z = 0f;
        this.gameObject.transform.position=eye_Player=eye_Player+new Vector3 (6f,-1f,0f);
        Nagasono.AudioScripts.AudioManager.PlayAudio("CutRun");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(2f* Time.deltaTime,0f,0f);
        if (this.transform.position.x < eye_Player.x - 10f)
        {
            //END
            fadeManager.SceneLoad();

        }
    }
}