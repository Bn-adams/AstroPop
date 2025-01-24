using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStorage : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer;
    public Sprite Water_storage_0;
    public Sprite Water_storage_1;
    public Sprite Water_storage_2;
    public Sprite Water_storage_3;
    public Sprite Water_storage_4;

    private PrivateVariables privateVariables;
    public Item water;
    private HotbarV2 hotbar;
    public int WaterAmountStored = 0;
    private int maxWaterStorage = 7;
    private void Start()
    {
        hotbar = GameObject.Find("HotbarEmpty").GetComponent<HotbarV2>();
        privateVariables = GameObject.Find("PlayerShipper").GetComponent<PrivateVariables>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetImage();

    }
    // Take oxygen out
    public void InteractQ()
    {
        
        if (hotbar.IsInventoryFull() == false)
        {
            if (WaterAmountStored >= 1)
            {
                WaterAmountStored -= 1;
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
        SetImage();

    }
    // Put oxygen into the storage
    public void InteractE()
    {
        if (hotbar.GetCurrentItem() != null)
        {
            if (hotbar.GetCurrentItem().itemName == "Water")
            {
                if (WaterAmountStored <= 6)
                {
                    hotbar.RemoveCurrentItem();
                    WaterAmountStored += 1;
                }
                else
                {
                    Debug.Log("max water");
                }
            }
        }
        SetImage();
    }
    public void SetImage()
    {
        if (WaterAmountStored >= 7)
        {
            spriteRenderer.sprite = Water_storage_4;
            return;
        }
        else if (WaterAmountStored >= 5)
        {
            spriteRenderer.sprite = Water_storage_3;
            return;
        }
        else if (WaterAmountStored >= 3)
        {
            spriteRenderer.sprite = Water_storage_2;
            return;
        }
        else if (WaterAmountStored > 0)
        {
            spriteRenderer.sprite = Water_storage_1;
            return;
        }
        else
        {
            spriteRenderer.sprite = Water_storage_0;
            return;
        }
    }
}

