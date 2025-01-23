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

    public bool iceIsBroken = false;
    public bool iceIsBraking = false;
    public bool iceIsOnTable = false;
    private bool iceShardIsCollectable = false;
    private bool hasSeedBeenCollected = false;

    public IceChunkWithSeed iceChunk;

    public float iceBreakTime = 5f;

    


    
    void Start()
    {
        hotbar = GameObject.Find("HotbarEmpty").GetComponent<HotbarV2>();
    }

    // Update is called once per frame
    void Update()
    {
        CrushIce();
    }

    public void InteractQ()
    {
        if (iceIsBroken && iceIsOnTable && !iceShardIsCollectable && !hasSeedBeenCollected)
        {
            GiveSeed();
            return;
        }
        if (iceShardIsCollectable && hasSeedBeenCollected)
        {
            GiveIceShard();
        }

    }

    public void InteractE()
    {
        if (IsIceChunk() && !iceIsOnTable)
        {
            TakeIceChunk();
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
        
        iceShardIsCollectable = true;
        hasSeedBeenCollected = true;
    }

    void GiveIceShard()
    {
        hotbar.PickupItem(iceShard);
        iceShardIsCollectable = false;
        hasSeedBeenCollected = false;
        ResetTable();
    }

    void CrushIce()
    {
        if (IsIceChunkOnTable())
        {
            iceBreakTime -= Time.deltaTime;

            if (iceBreakTime <= 0)
            {
                iceIsBroken = true;
                //iceIsBraking = false;
                iceBreakTime = 0;
            }
            else
            {
                iceIsBraking = true;
            }
        }
        // Change sprite maybe to show its broken
        
        
    }

    void ResetTable()
    {
        currentItem = null;
        iceBreakTime = 5;
        iceIsOnTable = false;
        iceIsBroken = false;
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

    bool IsIceChunkOnTable()
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
