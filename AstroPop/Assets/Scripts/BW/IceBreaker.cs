using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreaker : MonoBehaviour, IInteractable
{
    private Item currentItem;
   
    private HotbarV2 hotbar;

    [SerializeField] private Item iceShard;
    [SerializeField] private Item commonSeed;
    [SerializeField] private Item rareSeed;
    [SerializeField] private Item epicSeed;
    private Item tableSeed;

    private bool iceIsBroken = false;
    private bool iceIsBraking = false;
    private bool iceIsOnTable = false;
    private bool iceShardIsCollectable = false;
    private bool hasSeedBeenCollected = false;

    public IceChunkWithSeed iceChunk;
  

    public float iceBreakTime = 1f;

    public Animator animator;
    public GameObject AniClass;
    public GameObject IceSeed;

    
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
            IceSeed.SetActive(false);
            return;
        }
        if (iceShardIsCollectable && hasSeedBeenCollected)
        {
            GiveIceShard();
            AniClass.SetActive(false);
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
            AniClass.SetActive(true);
            animator.SetBool("IsBreaking",true);
            iceBreakTime -= Time.deltaTime;

            if (iceBreakTime <= 0)
            {
                animator.SetBool("IsBreaking", false);
                animator.SetBool("IsBroken", true);
                iceIsBroken = true;
                //iceIsBraking = false;
                iceBreakTime = 0;
                IceSeed.SetActive(true);
            }
            else
            {
                iceIsBraking = true;
            }
        }
    }

    void ResetTable()
    {
        currentItem = null;
        iceBreakTime = 5;
        iceIsOnTable = false;
        iceIsBroken = false;
        animator.SetBool("IsBroken", false);
        animator.SetBool("IsBreaking", false);
        IceSeed.SetActive(false);
        AniClass.SetActive(false);
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
