using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HotbarV2 : MonoBehaviour
{
    public Item[] items;
    public Image[] itemImages;

    public int[] hotbarArray = new int[9];

    private string itemInSlotName;
    public void Start()
    {
        // Set the items so there in an array
        items = new Item[9];
        itemImages = new Image[9];

        items = new Item[9];
        itemImages = new Image[9];

        // Assign each image using find, each hotbar slot must be names HI1 HI2 etc...
        for (int i = 0; i < 9; i++)
        {
            string imageName = $"HI{i + 1}";
            itemImages[i] = GameObject.Find(imageName)?.GetComponent<Image>();
            if (itemImages[i] == null) Debug.LogError($"Image {imageName} not found or missing Image component.");
        }

        // Sets the visibility of all the item slots to 0% so there isnt a blank white square.
        for (int i = 0; i < hotbarArray.Length; i++)
        {
            SetImageAlpha(0f, i);
        }
    }

    // This 
    public void PickupItem(Item pickupItem)
    {
        for (int i = 0; i < hotbarArray.Length; i++)
        {
            if (hotbarArray[i] == 0)
            {
                items[i] = pickupItem;
                Debug.Log("youve placed it at spot" + i);
                itemImages[i].sprite = items[i].hotbarIcon;
                hotbarArray[i] = 1;
                SetImageAlpha(1f, i);
                //set item at hotbar here
                break;
            }
        }
    }

    public void RemoveItem(int hotbarSlot)
    {
        if (!IsSlotEmpty(hotbarSlot))
        {
            // Set all the relevant hotbar variables
            items[hotbarSlot] = null;
            itemImages[hotbarSlot].sprite = null;
            SetImageAlpha(0f, hotbarSlot);
            hotbarArray[hotbarSlot] = 0;
        }
    }

    public Item GetCurrentItem()
    {
        // Change 0 to which item you want to get
        // Consider having an input to this function called hotbarSlot
        return items[0];
    }

    public bool IsSlotEmpty(int hotbarSlot)
    {
        if (hotbarArray[hotbarSlot] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        // Checks wether slot is empty and returns true if it is
    }

    public void SetImageAlpha(float alpha, int hotbarSlot)
    {
        Color currentColor = itemImages[hotbarSlot].color;          // Get the current color
        currentColor.a = Mathf.Clamp01(alpha);         // Set alpha (ensure it's between 0 and 1)
        itemImages[hotbarSlot].color = currentColor;                // Apply the updated color
    }

    public void Update()
    {
        // Cheat codes to get rid of items in hotbar
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            RemoveItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RemoveItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RemoveItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RemoveItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            RemoveItem(5);
        }
    }

    

}
