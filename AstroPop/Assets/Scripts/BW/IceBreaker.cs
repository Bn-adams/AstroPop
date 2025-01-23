using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreaker : MonoBehaviour, IInteractable
{
    private Item currentItem;
   
    public HotbarV2 hotbar;

    [SerializeField] private Item iceShard;
    [SerializeField] private Item commonSeed;
    [SerializeField] private Item rareSeed;
    [SerializeField] private Item epicSeed;
    private Item tableSeed;

    private bool iceIsBroken = false;
    private bool iceIsOnTable = false;

    public IceChunkWithSeed iceChunk;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractQ()
    {
        if (iceIsBroken)
        {
            GiveSeed();
        }
        
    }

    public void InteractE()
    {
        if (IsIceChunk() && !iceIsOnTable)
        {
            TakeIceChunk();
        }

        if (iceIsOnTable && !iceIsBroken) 
        {
            CrushIce();
        }

       
    }

    void TakeIceChunk()
    {
        if (hotbar.GetCurrentItem() is IceChunkWithSeed iceChunkWithSeed)
        {
            iceChunk = iceChunkWithSeed;
        }
        currentItem = hotbar.GetCurrentItem();
        hotbar.RemoveCurrentItem();
        iceIsOnTable = true;
    }

    void GiveSeed()
    {
        hotbar.PickupItem(GetIceSeed());
        iceIsBroken = false;
    }

    void GiveIceShard()
    {
        hotbar.PickupItem(iceShard);
    }

    void CrushIce()
    {
        // Change sprite maybe to show its broken
        iceIsBroken = true;
    }

    void ResetTable()
    {

    }

    bool IsIceOnTable()
    {
        // Checks if ice is in the machine
        if (currentItem != null)
        {
            return currentItem.itemType == "Ice Chunk";
        }
        else
        {
            return false;
        }
    }


    bool IsIceChunk()
    {
        // Checks if the player is holding ice in the highlighted slot
        return hotbar.GetCurrentItem().itemType == "Ice Chunk";
    }

    string GetCurrentItemName()
    {
        return hotbar.GetCurrentItem().itemName;
    }

    string GetCurrentSeedRarity()
    {
        return iceChunk.seedRarity;
    }

    private Item GetIceSeed()
    {
        Item ri = null;
        switch (GetCurrentSeedRarity())
        {
            case "Common":
                ri = commonSeed;
                break;
            case "Rare":
                ri = rareSeed;
                break;
            case "Epic":
                ri = epicSeed;
                break;
        }
        return ri;
    }
}
