using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    Text myText;

    // Start is called before the first frame update
    void Start()
    {
        float result = GimmickScore.Instance.Result();   //本来の計算処理
        //result = 100;   //仮置きの数字
        myText = GetComponentInChildren<Text>();
        myText.text = "Score : " + result + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
