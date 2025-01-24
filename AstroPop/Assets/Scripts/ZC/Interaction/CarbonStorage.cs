using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonStorage : MonoBehaviour, IInteractable
{
    private PrivateVariables privateVariables;
    private HotbarV2 hotbar;
    public int carbonAmountStored = 0;
    private int maxCarbonStorage = 100;

    private SpriteRenderer spriteRenderer;
    public Sprite car0;
    public Sprite car1;
    public Sprite car2;
    public Sprite car3;
    public Sprite car4;

    [SerializeField] private Item CarbonBubble;
    private void Start()
    {
        privateVariables = GameObject.Find("Player").GetComponent<PrivateVariables>();
        hotbar = GameObject.Find("HotbarEmpty").GetComponent<HotbarV2>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        carbonAmountStored = 0;
    }
    // Take oxygen out
    public void InteractQ()
    {
        //if (hotbar.GetCurrentItem() != null)
        //{
        //    if (hotbar.GetCurrentItem().itemType == "Oxygen")
        //    {
        //        Debug.Log("you have got more oxygen");
        //    }
        //}
        //if (privateVariables.Co2Amount < 95f)
        //{
        //    if (carbonAmountStored >= 10)
        //    {
        //        privateVariables.Co2Amount += 10;
        //        carbonAmountStored -= 10;
        //    }
        //    else if (carbonAmountStored < 0)
        //    {
        //        privateVariables.Co2Amount += carbonAmountStored;
        //        carbonAmountStored = 0;
        //    }
        //    else
        //    {
        //        Debug.Log("No stored oxygen left :(");
        //    }
        //}
        if (!hotbar.IsInventoryFull()) {
            if (carbonAmountStored >= 10)
            {
                carbonAmountStored -= 10;
                hotbar.PickupItem(CarbonBubble);
            }

            else
            {
                Debug.Log("No stored Carbon left :(");
            }
            SpritChange();
        }
        else
        {
            Debug.Log("your inventory is full");
        }
        SpritChange();

    }
    // Put oxygen into the storage
    public void InteractE()
    {
        if (hotbar.GetCurrentItem() != null)
        {
            if (hotbar.GetCurrentItem().itemName == "Co2")
            {
                if (carbonAmountStored < maxCarbonStorage)
                {
                    carbonAmountStored += 10;
                    hotbar.RemoveCurrentItem();
                }
            }
        }
        else if (privateVariables.CarbonAmount >= 10)
        {
            carbonAmountStored += 10;
            privateVariables.CarbonAmount -= 10;
        }
        SpritChange();
        //if (privateVariables.OxygenAmount > 15f && (oxygenAmountStored < maxOxygenStorage))
        //{
        //    oxygenAmountStored += 10;
        //    privateVariables.OxygenAmount -= 10;
        //    if (oxygenAmountStored > maxOxygenStorage)
        //    {
        //        privateVariables.OxygenAmount = oxygenAmountStored - maxOxygenStorage;
        //        oxygenAmountStored = maxOxygenStorage;

        //    }
        //}

    }
    public void SpritChange()
    {
        if (carbonAmountStored >= 100)
        {
            spriteRenderer.sprite = car4;
            return;
        }
        else if (carbonAmountStored >= 70)
        {
            spriteRenderer.sprite = car3;
            return;
        }
        else if (carbonAmountStored >= 40)
        {
            spriteRenderer.sprite = car2;
            return;
        }
        else if (carbonAmountStored >= 10)
        {
            spriteRenderer.sprite = car1;
            return;
        }
        else
        {
            spriteRenderer.sprite = car0;
            return;
        }

    }
}

