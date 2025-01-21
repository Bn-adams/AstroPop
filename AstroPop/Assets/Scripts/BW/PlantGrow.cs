using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour, IInteractable
{
    public Item plantItem;
    public Plant plant;
    public Hotbar hotbar;
    public Plant hotbarPlant;
    public SpriteRenderer spriteRenderer;
    private Sprite plantStage1;
    private Sprite plantStage2;
    private Sprite plantStage3;
    private Sprite plantStage4;
    public float plantTime = 0f;
    private float currentGrowthTime = 0f; // Reset growth time
    private float currentWaterLevel = 0f; // Reset water level

    public Plant plantedPlant;
    private bool seedIsPlanted = false;
    private bool IsHarvestable = false;

    public OxygenBar oxyBar;
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seedIsPlanted)
        {
            IsHarvestable = false;
            plantTime += Time.deltaTime;

            if (plantTime < plantedPlant.growthTime / 4)
            {
                spriteRenderer.sprite = plantStage1;
            }
            if (plantTime > plantedPlant.growthTime / 4 * 2)
            {
                spriteRenderer.sprite = plantStage2;
            }
            if (plantTime > plantedPlant.growthTime / 4 * 3)
            {
                spriteRenderer.sprite = plantStage3;
            }

            if (plantTime > plantedPlant.growthTime / 4 * 4)
            {
                spriteRenderer.sprite = plantStage4;
                IsHarvestable = true;
            }

            
        }
    }

    public void PlantSeed()
    {
        if (!seedIsPlanted)
        {
            if (hotbar.item is Plant plant)
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

            seedIsPlanted = true;
            hotbar.RemoveItem();
        }
    }
    public void Harvest()
    {
        if (IsHarvestable)
        {
            oxyBar.oxygen += plantedPlant.oxygenProduce;
            seedIsPlanted = false;
            plantedPlant = null;
            spriteRenderer.sprite = null;
        }
    }

    public void InteractQ()
    {
        Harvest();
    }
    public void InteractE()
    {
        
        PlantSeed();
    }

}
