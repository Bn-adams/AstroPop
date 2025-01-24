using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private HotbarV2 hotbar;
    private GrapplingGun grapplingGun;
    // Start is called before the first frame update
    void Start()
    {
        hotbar = GameObject.Find("HotbarEmpty").GetComponent<HotbarV2>();
        grapplingGun = GameObject.Find("GrapplingGun").GetComponent<GrapplingGun>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (hotbar == null)
        //{
        //    Debug.LogError("U suck");
        //}
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Item"))
        {
            WorldItem worldItem = collision.collider.GetComponent<WorldItem>();
            hotbar.PickupItem(worldItem.item);
            collision.gameObject.SetActive(false);
            if (grapplingGun)
            {
                grapplingGun.BreakGrapple();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            WorldItem worldItem = collision.GetComponent<WorldItem>();
            hotbar.PickupItem(worldItem.item);
            collision.gameObject.SetActive(false);

            if (grapplingGun)
            {
                grapplingGun.BreakGrapple();
            }
        }
    }

        }
    }

}
