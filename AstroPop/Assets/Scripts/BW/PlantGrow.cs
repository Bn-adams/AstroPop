using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour, IInteractable
{
    public PrivateVariables privateVariables;
    public Item plantItem;
    public Plant plant;
    public HotbarV2 hotbar;

    public Plant hotbarPlant;

    // Plant sprites
    public SpriteRenderer spriteRendererPlant;
    private Sprite plantStage1;
    private Sprite plantStage2;
    private Sprite plantStage3;
    private Sprite plantStage4;

    // This pods sprites
    public SpriteRenderer spriteRendererPod;
    public Sprite Pod00;
    public Sprite Pod10;
    public Sprite Pod01;
    public Sprite Pod11;
    private bool P00;
    private bool P10;
    private bool P01;
    private bool P11;


    public float plantTime = 0f;
    private float currentGrowthTime = 0f; // Reset growth time
    private float currentWaterLevel = 0f; // Reset water level
    private float currentCo2Level = 0f;

    public Plant plantedPlant;
    private bool seedIsPlanted = false;
    private bool IsHarvestable = false;

    public OxygenBar oxyBar;


    private float growthPodWaterLevel;
    private float growthPodWaterNeeded;

    private float growthPodCarbonLevel;
    private float growthPodCarbonNeeded;

    [SerializeField] private Item oxygenBubble;


    // Start is called before the first frame update
    void Start()
    {
        privateVariables = GameObject.Find("Player").GetComponent<PrivateVariables>();
        spriteRendererPod = GetComponent<SpriteRenderer>();
        P00 = true;
        P10 = false;
        P01 = false;
        P11 = false;
        spriteChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (seedIsPlanted)
        {
            if (!IsFullyWatered())
            {
                spriteRendererPlant.sprite = plantStage1;
            }
            else if (IsFullyWatered() && IsFullyCarbonated()) 
                {
                IsHarvestable = false;
                plantTime += Time.deltaTime;

                if (plantTime < plantedPlant.growthTime / 4)
                {
                    spriteRendererPlant.sprite = plantStage1;
                }
                if (plantTime > plantedPlant.growthTime / 4 * 2)
                {
                    spriteRendererPlant.sprite = plantStage2;
                }
                if (plantTime > plantedPlant.growthTime / 4 * 3)
                {
                    spriteRendererPlant.sprite = plantStage3;
                }

                if (plantTime > plantedPlant.growthTime / 4 * 4)
                {
                    spriteRendererPlant.sprite = plantStage4;
                    IsHarvestable = true;
                }
            }
        }
    }

    public void PlantSeed()
    {
        if (!seedIsPlanted)
        {
            if (hotbar.items[hotbar.currentHighlightenSlot] is Plant plant)
            {
                hotbarPlant = plant;
                plantedPlant = hotbarPlant;
            }

            if (plantedPlant != null && hotbarPlant != null)
            {
                plantedPlant.growthTime = hotbarPlant.growthTime;
            }
            else
            {
                Debug.LogWarning("Either plantedPlant or hotbarPlant is null!");
            }

            plantTime = 0;

            plantStage1 = plantedPlant.growthStage1;
            plantStage2 = plantedPlant.growthStage2;
            plantStage3 = plantedPlant.growthStage3;
            plantStage4 = plantedPlant.growthStage4;

            growthPodWaterNeeded = plantedPlant.waterNeeded;
            growthPodCarbonNeeded = plantedPlant.CO2Needed;

            seedIsPlanted = true;
            hotbar.RemoveCurrentItem();
        }
    }
    public void Harvest()
    {
        if (IsHarvestable)
        {
            privateVariables.OxygenAmount += plantedPlant.oxygenProduce;
            hotbar.PickupItem(oxygenBubble);
            seedIsPlanted = false;
            plantedPlant = null;
            spriteRendererPlant.sprite = null;
            growthPodWaterLevel = 0;
            growthPodCarbonLevel = 0;
            P00 = true;
            P10 = false;
            P01 = false;
            P11 = false;
            spriteChange();
        }
    }

    public void InteractQ()
    {
        Harvest();
    }
    public void InteractE()
    { 
        if (hotbar.GetCurrentItem() != null)
        {
            if (hotbar.GetCurrentItem().itemType == "Seed")
            {
                PlantSeed();
            }

            else if (hotbar.GetCurrentItem().itemName == "Water")
            {
                WaterPlant();
            }

            else if (hotbar.GetCurrentItem().itemName == "Co2")
            {
                CarbonatePlant();
            }
        }
    }

    public void WaterPlant()
    {
        if (!IsFullyWatered())
        {
            growthPodWaterLevel++;
            hotbar.RemoveCurrentItem();
            P00 = false;
            P10 = true;
            P01 = false;
            P11 = false;
            spriteChange();
        }
    }

    
    public void CarbonatePlant()
    {
        if (!IsFullyCarbonated())
        {
            growthPodCarbonLevel++;
            hotbar.RemoveCurrentItem();
            P00 = false;
            P10 = true;
            P01 = false;
            P11 = false;
            spriteChange();
        }
    }

    private bool IsFullyWatered()
    {
        return growthPodWaterLevel >= growthPodWaterNeeded;
    }
    private bool IsFullyCarbonated()
    {
        return growthPodCarbonLevel >= growthPodCarbonNeeded;
    }
    public void spriteChange()
    {
        if (P00)
        {
            spriteRendererPod.sprite = Pod00;
        }
        if (P10)
        {
            spriteRendererPod.sprite = Pod10;
        }
        if (P01)
        {
            spriteRendererPod.sprite = Pod01;
        }
        if (P11)
        {
            spriteRendererPod.sprite = Pod11;
        }

    }
}
