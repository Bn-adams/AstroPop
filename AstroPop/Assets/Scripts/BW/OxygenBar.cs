using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    private Slider oxygenBar;
    private float maxOxygen = 100f;
    public float oxygen;
    private float oxygenDepleteInterval = 2f;
    private float oxygenDepleteTimer;
    private float oxygenDepleteAmount = 1f;
    // Start is called before the first frame update
    void Start()
    {
        oxygenBar = GetComponent<Slider>();
        oxygenBar.maxValue = maxOxygen;
        oxygen = maxOxygen;
        oxygenDepleteTimer = oxygenDepleteInterval;
    }

    // Update is called once per frame
    void Update()
    {
        oxygenBar.value = oxygen;
        oxygenDepleteTimer -= Time.deltaTime;

        if (oxygenDepleteTimer <= 0)
        {
            oxygen -= 0.5f;
            oxygenDepleteTimer = 2f;
        }
    }
}
