using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollison : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided with " +  collision.gameObject.name);
        
    }
}
