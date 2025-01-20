using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Sprite plantStage1;
    private Sprite plantStage2;
    private Sprite plantStage3;
    private Sprite plantStage4;
    public float plantTime = 0f;
    private float currentGrowthTime = 0f; // Reset growth time
    private float currentWaterLevel = 0f; // Reset water level

    public Plant plantedPlant;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        plantStage1 = plantedPlant.growthStage1;
        plantStage2 = plantedPlant.growthStage2;
        plantStage3 = plantedPlant.growthStage3;
        plantStage4 = plantedPlant.growthStage4;
    }

    // Update is called once per frame
    void Update()
    {
        plantTime += Time.deltaTime;

        if (plantTime > 10f)
        {
            spriteRenderer.sprite = plantStage1;
        }
        if( plantTime > 20f)
        {
            spriteRenderer.sprite = plantStage2;
        }
        if (plantTime > 30f)
        {
            spriteRenderer.sprite = plantStage3;
        }

        if (plantTime > 40f)
        {
            spriteRenderer.sprite = plantStage4;
        }

        if (spriteRenderer.sprite == plantStage3)
        {
            // This is conditional to say when the plant is fully grown, could be a bool
            
        }
    }

    public void PlantSeed(Plant plant)
    {
        plantedPlant = plant;
        plantTime = 0f;       
        currentGrowthTime = 0f; // Reset growth time
        currentWaterLevel = 0f; // Reset water level
    }
    public void PlantPickup()
    {

    }


}
