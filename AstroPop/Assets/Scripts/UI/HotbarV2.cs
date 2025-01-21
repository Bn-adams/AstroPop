using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HotbarV2 : MonoBehaviour
{
    public Item item;

    private Image[] itemImages;
    public Image itemImage1;
    public Image itemImage2;
    public Image itemImage3;
    public Image itemImage4;
    public Image itemImage5;
    public Image itemImage6;
    public Image itemImage7;
    public Image itemImage8;
    public Image itemImage9;

    private SpriteRenderer[] itemRenderers;
    public SpriteRenderer itemRenderer1;
    public SpriteRenderer itemRenderer2;
    public SpriteRenderer itemRenderer3;
    public SpriteRenderer itemRenderer4;
    public SpriteRenderer itemRenderer5;
    public SpriteRenderer itemRenderer6;
    public SpriteRenderer itemRenderer7;
    public SpriteRenderer itemRenderer8;
    public SpriteRenderer itemRenderer9;

    public int[] hotbarArray = new int[9];

    private string itemInSlotName;
    public void Start()
    {
        // Initialize the array and assign the images
        itemImages = new Image[]
        {
            itemImage1,
            itemImage2,
            itemImage3,
            itemImage4,
            itemImage5,
            itemImage6,
            itemImage7,
            itemImage8,
            itemImage9
        };
        itemRenderers = new SpriteRenderer[]
        {
            itemRenderer1,
            itemRenderer2,
            itemRenderer3,
            itemRenderer4,
            itemRenderer5,
            itemRenderer6,
            itemRenderer7,
            itemRenderer8,
            itemRenderer9
        };
        for (int i = 0; i < hotbarArray.Length; i++)
        {
            SetImageAlpha(0f, i);
        }
        Debug.Log(itemImages.Length);
        
    }

    public void PickupItem(Item pickupItem)
    {
        Debug.Log(itemImages[0]);
        item = pickupItem;


        //if (IsSlotEmpty())
        //{
        //    item = pickupItem;
        //    // Set all the relevant hotbar variables

        //    itemImage1.sprite = item.hotbarIcon;
        //    SetImageAlpha(1f);

        //}
        //else
        //{
        //    Debug.Log("Slot is occupied");
        //}

        //hotbarArray[0] = 1;
        //hotbarArray[1] = 2;

        for (int i = 0; i < hotbarArray.Length; i++)
        {
            if (hotbarArray[i] == 0)
            {
                Debug.Log("youve placed it at spot" + i);
                itemImages[i].sprite = item.hotbarIcon;
                hotbarArray[i] = 1;
                SetImageAlpha(1f, i);
                //set item at hotbar here
                break;
            }

        }
        Debug.Log(itemImages[0]);
        //for (int i = 0; i < itemImages.Length; i++)
        //{
        //    if (itemImages[i] == null)
        //    {
        //        itemImages[i].sprite = item.hotbarIcon;
        //        SetImageAlpha(1f, i);
        //        break;
        //    }
        //}


        //itemImage2.sprite = item.hotbarIcon;

        //SetImageAlpha(1f);

    }

    public void RemoveItem(int hotbarSlot)
    {
        if (!IsSlotEmpty(hotbarSlot))
        {
            // Set all the relevant hotbar variables

            item = null;
            itemImages[hotbarSlot].sprite = null;
            SetImageAlpha(0f, hotbarSlot);
            hotbarArray[hotbarSlot] = 0;
        }
    }

    public Item GetCurrentItem()
    {
        return item;
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
        //return item == null;
    }

    public void SetImageAlpha(float alpha, int hotbarSlot)
    {
        Color currentColor = itemImages[hotbarSlot].color;          // Get the current color
        currentColor.a = Mathf.Clamp01(alpha);         // Set alpha (ensure it's between 0 and 1)
        itemImages[hotbarSlot].color = currentColor;                // Apply the updated color
    }

    public void Update()
    {
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
