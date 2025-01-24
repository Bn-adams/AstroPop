using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OxygenBar : MonoBehaviour
{
    private PrivateVariables privateVariables;
    private Slider oxygenBar;
    private float maxOxygen = 100f;
    private float oxygenDepleteTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {

        privateVariables = GameObject.Find("PlayerShipper").GetComponent<PrivateVariables>();

        oxygenBar = GetComponent<Slider>();
        oxygenBar.maxValue = maxOxygen;
        //Debug.Log(privateVariables.OxygenAmount);
        privateVariables.OxygenAmount = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        oxygenDepleteTimer -= Time.deltaTime;

        if (oxygenDepleteTimer <= 0)
        {
            privateVariables.OxygenAmount = privateVariables.OxygenAmount - 0.5f;
            oxygenDepleteTimer = 2f;
        }
        if(privateVariables.OxygenAmount < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void setOxygenBar(float oxygen)
    {
        if (oxygenBar != null)
        {
            oxygenBar.value = oxygen;

        }
    }
}
