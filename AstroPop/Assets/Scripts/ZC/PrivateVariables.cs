using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateVariables : MonoBehaviour
{
    // Player stats
    private int playerLevel;
    private int playerDayTally;
    private int playerHealth;

    // Player values
    private int oxygenAmount;
    private int co2Amount;
    
    public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public int PlayerDayTally { get => playerDayTally; set => playerDayTally = value; }
    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public int OxygenAmount { get => oxygenAmount; set => oxygenAmount = value; }
    public int Co2Amount { get => co2Amount; set => co2Amount = value;  }

}
