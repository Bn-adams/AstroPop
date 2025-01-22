using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateVariables : MonoBehaviour
{
    public OxygenBar oxygenBar;
    // Player stats
    private int playerLevel;
    private int playerDayTally;
    private int playerHealth;

    // Player values
    private float oxygenAmount;
    private int co2Amount;

    public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public int PlayerDayTally { get => playerDayTally; set => playerDayTally = value; }
    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public float OxygenAmount
    {
        get => oxygenAmount;
        set
        {
            //oxygenAmount = value;
            if (value < 0f) oxygenAmount = 0f;
            else if (value > 100f) oxygenAmount = 100f;
            else oxygenAmount = value;
            Debug.Log(oxygenAmount);
            oxygenBar.setOxygenBar(value);
        }
    }
    //public float OxygenAmount { get => oxygenAmount; set => oxygenAmount = value; }
        
    public int Co2Amount { get => co2Amount; set => co2Amount = value;  }

}
