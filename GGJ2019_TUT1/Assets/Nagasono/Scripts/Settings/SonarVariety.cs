using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SonarVariety", fileName = "new SonarVariety")]
public class SonarVariety : ScriptableObject
{   
    [SerializeField] private float speed;

    [SerializeField] private int amount;
    [SerializeField] private float delaySpeed;

    [SerializeField] private float dashSonarRate;

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

    public float DashSonarRate
    {
        get { return dashSonarRate; }
    }

    public void BootSonar(GameObject sonarObject, Transform hostTransform)
    {
        var soloAngle = Mathf.PI * 2 / Amount;
        for (var i = 0; i < Amount; i++)
        {
            var tmpSonar = Instantiate(sonarObject, hostTransform.position, Quaternion.identity).GetComponent<Sonar>();
            tmpSonar.moveVector = new Vector3(Speed * Mathf.Sin(soloAngle * i),
                Speed * Mathf.Cos(soloAngle * i));
            tmpSonar.delaySpeed = DelaySpeed;
        }
    }
}
