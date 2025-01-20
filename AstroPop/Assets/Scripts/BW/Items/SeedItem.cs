using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedItem : MonoBehaviour
{
    public Plant plantData;
    private SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        sR.sprite = plantData.hotbarIcon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
