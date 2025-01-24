using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherScript : MonoBehaviour
{
    public bool isTarget1;
    // Target 1
    public GameObject playerShipper;

    //Target2
    public GameObject playerSwinger;
    

    // Start is called before the first frame update
    void Start()
    {
        isTarget1 = true;

        playerShipper.SetActive(true);
        playerSwinger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTarget1)
        {
            playerSwinger.transform.position = new Vector2(playerSwinger.transform.position.x - 2f, playerSwinger.transform.position.y);
            
            isTarget1 = false;
            playerShipper.SetActive(false);
            playerSwinger.SetActive(true);

        }
        else
        {
            playerShipper.transform.position = new Vector2(playerShipper.transform.position.x + 2f, playerShipper.transform.position.y);

            isTarget1 = true;
            playerShipper.SetActive(true);
            playerSwinger.SetActive(false);
        }
    }
}
