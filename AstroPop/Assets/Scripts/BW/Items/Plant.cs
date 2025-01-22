using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Items/Plant")]
public class Plant : Item
{              
    public float growthTime;          
    public Sprite growthStage1;     
    public Sprite growthStage2;     
    public Sprite growthStage3;     
    public Sprite growthStage4;
    public float waterNeeded;
    public float CO2Needed;
    public float oxygenProduce = 10;
}
