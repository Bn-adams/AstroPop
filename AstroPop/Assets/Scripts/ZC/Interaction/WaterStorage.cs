using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStorage : MonoBehaviour, IInteractable
{
    public PrivateVariables privateVariables;
    public HotbarV2 hotbar;
    public int oxygenAmountStored = 0;
    private int maxOxygenStorage = 400;
    private void Start()
    {
        privateVariables = GameObject.Find("Player").GetComponent<PrivateVariables>();
    }
    // Take oxygen out
    public void InteractQ()
    {
        if (hotbar.GetCurrentItem() != null)
        {
            if (hotbar.GetCurrentItem().itemType == "Oxygen")
            {
                Debug.Log("you have got more oxygen");
            }
        }
        if (privateVariables.OxygenAmount < 95f)
        {
            if (oxygenAmountStored >= 10)
            {
                privateVariables.OxygenAmount += 10;
                oxygenAmountStored -= 10;
            }
            else if (oxygenAmountStored < 0)
            {
                privateVariables.OxygenAmount += oxygenAmountStored;
                oxygenAmountStored = 0;
            }
            else
            {
                Debug.Log("No stored oxygen left :(");
            }
        }
    }
    // Put oxygen into the storage
    public void InteractE()
    {
        if (privateVariables.OxygenAmount > 15f && (oxygenAmountStored < maxOxygenStorage))
        {
            oxygenAmountStored += 10;
            privateVariables.OxygenAmount -= 10;
            if (oxygenAmountStored > maxOxygenStorage)
            {
                privateVariables.OxygenAmount = oxygenAmountStored - maxOxygenStorage;
                oxygenAmountStored = maxOxygenStorage;

            }
        }
    }
}

