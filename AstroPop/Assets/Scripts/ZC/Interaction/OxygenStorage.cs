using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenStorage : MonoBehaviour, IInteractable
{
    private PrivateVariables privateVariables;
    private HotbarV2 hotbar;
    public int oxygenAmountStored = 0;
    private int maxOxygenStorage = 100;

    private SpriteRenderer spriteRenderer;
    public Sprite Ox0;
    public Sprite Ox1;
    public Sprite Ox2;
    public Sprite Ox3;
    public Sprite Ox4;
    private void Start()
    {
        privateVariables = GameObject.Find("PlayerShipper").GetComponent<PrivateVariables>();
        hotbar = GameObject.Find("HotbarEmpty").GetComponent<HotbarV2>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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
        SpritChange();
    }
    // Put oxygen into the storage
    public void InteractE()
    {
        if (hotbar.GetCurrentItem() != null)
        {
            if (hotbar.GetCurrentItem().itemName == "Oxygen")
            {
                if (oxygenAmountStored < maxOxygenStorage)
                {
                    oxygenAmountStored += 10; 
                    hotbar.RemoveCurrentItem();
                }
            }
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
        if (oxygenAmountStored >= 100)
        {
            spriteRenderer.sprite = Ox4;
            return;
        }
        else if (oxygenAmountStored >= 70)
        {
            spriteRenderer.sprite = Ox3;
            return;
        }
        else if (oxygenAmountStored >= 40)
        {
            spriteRenderer.sprite = Ox2;
            return;
        }
        else if (oxygenAmountStored >= 10)
        {
            spriteRenderer.sprite = Ox1;
            return;
        }
        else
        {
            spriteRenderer.sprite = Ox0;
            return;
        }

    }
}

