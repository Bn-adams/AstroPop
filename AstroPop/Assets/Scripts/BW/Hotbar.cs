using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public Image item;
    private bool itemInSlot = false;
    private string itemInSlotName;

    public void PickupItem(string itemName)
    {
        if (IsSlotEmpty())
        {
            itemInSlotName = itemName;
        }
        else
        {
            Debug.Log("Slot is occupied");
        }
    }

    public void RemoveItem()
    {
        if (!IsSlotEmpty())
        {
            
        }
    }

    public void GetCurrentItem()
    {
        
    }

    public bool IsSlotEmpty()
    {
        // Checks wether slot is empty and returns true if it is
        return !itemInSlot;    
    }
}
