using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : Item
{             
    public GameObject plantPrefab;    
    public float growthTime;          
    public Sprite growthStage1;     
    public Sprite growthStage2;     
    public Sprite growthStage3;     
    public Sprite growthStage4;
    public float waterLevel = 0;
    public float CO2 = 0;
    public float oxygenProduce = 10;
}
