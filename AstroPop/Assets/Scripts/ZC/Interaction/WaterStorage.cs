using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStorage : MonoBehaviour, IInteractable
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    public PrivateVariables privateVariables;
    public Item water;
    public HotbarV2 hotbar;
    public int WaterAmountStored = 0;
    private int maxWaterStorage = 400;
    private void Start()
    {
        privateVariables = GameObject.Find("Player").GetComponent<PrivateVariables>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Take oxygen out
    public void InteractQ()
    {
        
        if (hotbar.IsInventoryFull() == false)
        {
            if (WaterAmountStored >= 20)
            {
                WaterAmountStored -= 20;
                hotbar.PickupItem(water);

            }
            else
            {
                Debug.Log("no water left");
            }
        }
        else
        {
            Debug.Log("inventory full");
        }
    }
    // Put oxygen into the storage
    public void InteractE()
    {
        if (hotbar.GetCurrentItem() != null)
        {
            if (hotbar.GetCurrentItem().itemName == "Water")
            {
                if (WaterAmountStored <= 380)
                {
                    hotbar.RemoveCurrentItem();
                    WaterAmountStored += 20;
                }
                else
                {
                    Debug.Log("max water");
                }
            }
        }
        spriteRenderer.sprite = sprite1;
    }
    public void SetImage()
    {
        if (WaterAmountStored > )
    }
}

