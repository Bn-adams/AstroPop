using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite plantStage1;
    public Sprite plantStage2;
    public Sprite plantStage3;
    public float plantTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (spriteRenderer.sprite == plantStage3)
        {
            // This is conditional to say when the plant is fully grown, could be a bool
            
        }
    }
}
