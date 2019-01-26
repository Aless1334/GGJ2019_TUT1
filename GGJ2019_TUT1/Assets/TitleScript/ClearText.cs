using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    float getScore; //渡してもらうスコア
    public float MaxScore;
    Text myText;

    // Start is called before the first frame update
    void Start()
    {
        getScore = GimmickScore.Instance.GetPoint();
        float result;
        result = getScore / MaxScore * 100;   //本来の計算処理
        //result = 100;   //仮置きの数字
        myText = GetComponentInChildren<Text>();
        myText.text = "Score : " + result + "%";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
