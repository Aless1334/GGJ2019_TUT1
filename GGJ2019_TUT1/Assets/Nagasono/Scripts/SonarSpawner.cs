using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarSpawner : MonoBehaviour
{
    [SerializeField] private SonarVariety sonarSetting;
    [SerializeField] private Sonar sonar;

    public SonarVariety SonarSetting
    {
        set { sonarSetting = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            BootSonar();
    }

    public void BootSonar()
    {
        var soloAngle = Mathf.PI * 2 / sonarSetting.Amount;
        for (var i = 0; i < sonarSetting.Amount; i++)
        {
            var tmpSonar = Instantiate(sonar.gameObject, transform.position, Quaternion.identity).GetComponent<Sonar>();
            tmpSonar.moveVector = new Vector3(sonarSetting.Speed * Mathf.Sin(soloAngle * i),
                sonarSetting.Speed * Mathf.Cos(soloAngle * i));
            tmpSonar.delaySpeed = sonarSetting.DelaySpeed;
        }
    }
}
