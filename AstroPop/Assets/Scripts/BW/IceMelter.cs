using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelter : MonoBehaviour, IInteractable
{
    public Item currentItem;
    public Item water;
    public HotbarV2 hotbar;
    public float iceMeltTime = 10;
    private bool iceHasMelted = false;
    private bool iceIsMelting = false; // bool to tell machine to not except ice when its still melting

    private SpriteRenderer sR;
    [SerializeField] Sprite off;
    [SerializeField] Sprite on;
    [SerializeField] Sprite finished;

    void Start()
    {
        hotbar = GameObject.Find("HotbarEmpty").GetComponent<HotbarV2>();
        sR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // This counts down the timer when ice is put into the machine and sets a bool when its done
        if (IsIceInMachine() && !iceHasMelted)
        {
            iceMeltTime -= Time.deltaTime;

            if (iceMeltTime <= 0)
            {
                iceHasMelted = true;
                iceIsMelting = false; 
            }
            else
            {
                iceIsMelting = true;
            }
        }

        if (iceIsMelting)
        {
            sR.sprite = on;
        }
        else if (iceHasMelted)
        {
            sR.sprite = finished;
        }
        else if (!iceIsMelting && !iceHasMelted)
        {
            sR.sprite = off;
        }
    }

    public void InteractQ()
    {
        // pull out water
        if (IsIceInMachine() && iceHasMelted)
        {
            GiveWater();
        }
    }

    public void InteractE()
    {
        if (IsIceShard() && !iceIsMelting && !iceHasMelted)
        {
            TakeIceShard();
        }
    }

    void TakeIceShard()
    {
        // This method should tell the ice machine that there is ice in it and take it off the hotbar
        currentItem = hotbar.GetCurrentItem();
        hotbar.RemoveCurrentItem();
    }

    void GiveWater()
    {
        // This method sets the current item to water and gives it to the player 
        currentItem = water;
        hotbar.PickupItem(currentItem);
        ResetIceMachine();
    }

    void ResetIceMachine()
    {
        // Resets relavent machine variables
        currentItem = null;
        iceMeltTime = 10;
        iceHasMelted = false;
    }
    bool IsIceInMachine()
    {
        // Checks if ice is in the machine
        if (currentItem != null)
        {
            return currentItem.itemName == "Ice Shard";
        }
        else
        {
            return false;
        }
    }

    bool IsIceShard()
    {
        // Checks if the player is holding ice in the highlighted slot
        return hotbar.GetCurrentItem().itemName == "Ice Shard";
    }
}
