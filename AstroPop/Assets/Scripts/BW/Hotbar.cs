using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public Item item;
    public Image itemImage;
    public SpriteRenderer itemRenderer;
    private bool itemInSlot = false;
    private string itemInSlotName;

    public void PickupItem(Item pickupItem)
    {
        if (IsSlotEmpty())
        {
            item = pickupItem;
            // Set all the relevant hotbar variables
           
            itemImage.sprite = item.hotbarIcon;
            SetImageAlpha(1f); 

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

    public Item GetCurrentItem()
    {
        return item;
    }

    public bool IsSlotEmpty()
    {
        // Checks wether slot is empty and returns true if it is
        return !itemInSlot;    
    }

    public void SetImageAlpha(float alpha)
    {
        Color currentColor = itemImage.color;          // Get the current color
        currentColor.a = Mathf.Clamp01(alpha);         // Set alpha (ensure it's between 0 and 1)
        itemImage.color = currentColor;                // Apply the updated color
    }

    public void Update()
    {
       
    }

    public void Start()
    {
        SetImageAlpha(0f);
    }

}
