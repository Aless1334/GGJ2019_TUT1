using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarSpawner : MonoBehaviour
{
    private const float NormalSonarRate = 2.0f;
    
    [SerializeField] private SonarVariety sonarSetting;
    [SerializeField] private Sonar sonar;

    private PlayerController player;
    private float restShootSonarTime;

    public SonarVariety SonarSetting
    {
        set { sonarSetting = value; }
    }

    private void Start()
    {
        player = GetComponent<PlayerController>();
        restShootSonarTime = NormalSonarRate;
    }

    // Update is called once per frame
    void Update()
    {
        restShootSonarTime -= ((player.Moving) ? sonarSetting.DashSonarRate : 1) * Time.deltaTime;
        if (restShootSonarTime < 0)
        {
            BootSonar();
            restShootSonarTime = NormalSonarRate;
        }
    }

    public void BootSonar()
    {
        sonarSetting.BootSonar(sonar.gameObject, transform);
    }
}
