using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SonarVariety", fileName = "new SonarVariety")]
public class SonarVariety : ScriptableObject
{
    [SerializeField] private float speed;

    [SerializeField] private int amount;
    [SerializeField] private float delaySpeed;

    public float Speed
    {
        get { return speed; }
    }

    public int Amount
    {
        get { return amount; }
    }

    public float DelaySpeed
    {
        get { return delaySpeed; }
    }
}
