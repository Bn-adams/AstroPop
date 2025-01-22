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
    public Image[] slotHighlighted;

    public int[] hotbarArray = new int[9];
    public int currentHighlightenSlot = 0;

    private string itemInSlotName;
    public void Start()
    {
        // Set the items so there in an array
        items = new Item[9];
        itemImages = new Image[9];
        slotHighlighted = new Image[9];

        // Assign each image using find, each hotbar slot must be names HI1 HI2 etc...
        for (int i = 0; i < 9; i++)
        {
            string imageName = $"HI{i + 1}";
            itemImages[i] = GameObject.Find(imageName)?.GetComponent<Image>();
            if (itemImages[i] == null) Debug.LogError($"Image {imageName} not found or missing Image component.");
            string slotName = $"ItemFrame{i + 1}";
            slotHighlighted[i] = GameObject.Find(slotName)?.GetComponent<Image>();
            if(slotHighlighted[i] == null) Debug.LogError($"Image {slotName} not found or missing Image component.");
        }

        // Sets the visibility of all the item slots to 0% so there isnt a blank white square.
        for (int i = 0; i < hotbarArray.Length; i++)
        {
            SetImageAlpha(0f, i);
        }
        // Defult sets the first slot as highlighted
        SethotbarHighlightedAlpha(1, 0);
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

    public Item GetCurrentItem(int hotbarSlot)
    {
        return items[hotbarSlot];
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
    }

    public void SetImageAlpha(float alpha, int hotbarSlot)
    {
        Color currentColor = itemImages[hotbarSlot].color;          // Get the current color
        currentColor.a = Mathf.Clamp01(alpha);         // Set alpha (ensure it's between 0 and 1)
        itemImages[hotbarSlot].color = currentColor;                // Apply the updated color
    }
    public void SethotbarHighlightedAlpha(float alpha, int hotbarSlot)
    {
        Color currentColor = slotHighlighted[hotbarSlot].color;
        currentColor.a = Mathf.Clamp01(alpha);
        slotHighlighted[hotbarSlot].color = currentColor;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(GetCurrentItem(currentHighlightenSlot).name);
        }
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
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0)
        {
            if (currentHighlightenSlot == 0)
            {
                currentHighlightenSlot = 5;
                for (int i = 0; i < 6; i++)
                {
                    if (i == currentHighlightenSlot)
                    {
                        SethotbarHighlightedAlpha(1, i);
                    }
                    else SethotbarHighlightedAlpha(0.25f, i);
                }

            }
            else
            {
                currentHighlightenSlot--;
                for (int i = 0; i < 6; i++)
                {
                    if (i == currentHighlightenSlot)
                    {
                        SethotbarHighlightedAlpha(1, i);
                    }
                    else SethotbarHighlightedAlpha(0.25f, i);
                }
            }
        }
        if (scroll < 0) 
        {
            if (currentHighlightenSlot == 5)
            {
                currentHighlightenSlot = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (i == currentHighlightenSlot)
                    {
                        SethotbarHighlightedAlpha(1, i);
                    }
                    else SethotbarHighlightedAlpha(0.25f, i);
                }
            }
            else
            {
                currentHighlightenSlot++;
                for (int i = 0; i < 6; i++)
                {
                    if (i == currentHighlightenSlot)
                    {
                        SethotbarHighlightedAlpha(1, i);
                    }
                    else SethotbarHighlightedAlpha(0.25f, i);
                }
            }
        }
    }
}
