using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenStorage : MonoBehaviour, IInteractable
{
    public HotbarV2 hotbar;
    public int oxygenAmount;
    public void InteractQ()
    {
        if (hotbar.GetCurrentItem().itemType == "Oxygen")
        {

        }
        Debug.Log("Plant B says QQQQQ!");

    }
    public void InteractE()
    {
        Debug.Log("Plant B says EEEEE!");
    }
}

