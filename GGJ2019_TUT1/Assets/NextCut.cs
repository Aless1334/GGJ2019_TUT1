
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCut : MonoBehaviour
{
    private Vector3 eye_Player;

    // Start is called before the first frame update
    void Start()
    {
        eye_Player = GameObject.Find("Main Camera").transform.position;
        eye_Player.z = 0f;
        this.gameObject.transform.position=eye_Player=eye_Player+new Vector3 (4f,-1f,0f);
        Nagasono.AudioScripts.AudioManager.PlayAudio("CutRun");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(2f* Time.deltaTime,0f,0f);
    }
}