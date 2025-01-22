using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ice", menuName = "Ice")]
public class Ice: Item
{
    public GameObject icePrefab;
    public float meltTime;
    public Sprite iceSprite;
    public Sprite bigIceSprite;

    public float meltWaterLevel = 0;
    
}
