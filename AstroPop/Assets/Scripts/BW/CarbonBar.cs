using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbonBar : MonoBehaviour
{
    private PrivateVariables privateVariables;
    private Slider carbonBar;
    private float maxCarbon = 100f;
    private float CarbonDepleteTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {

        privateVariables = GameObject.Find("PlayerShipper").GetComponent<PrivateVariables>();

        carbonBar = GetComponent<Slider>();
        carbonBar.maxValue = maxCarbon;
        //Debug.Log(privateVariables.OxygenAmount);
        privateVariables.CarbonAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        CarbonDepleteTimer -= Time.deltaTime;

        if (CarbonDepleteTimer <= 0)
        {
            privateVariables.CarbonAmount = privateVariables.CarbonAmount + 0.5f;
            CarbonDepleteTimer = 2f;
        }
    }
    public void setCarbonBar(float carbon)
    {
        if (carbonBar != null)
        {
            carbonBar.value = carbon;

        }
    }
}
