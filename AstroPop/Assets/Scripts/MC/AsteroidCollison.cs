using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollison : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with " +  collision.gameObject.name);
        
        if(collision.gameObject.tag != "Player") return;

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        
        Vector2 velocity = rb.velocity;
        float Speed = rb.velocity.magnitude;

        if (5 < Speed && Speed < 10)
        {
            Debug.Log("minor collision");
        }
        else if (Speed < 15)
        {
            Debug.Log("major collision");
        }
        else
        {
            Debug.Log("Critical collision");
            PlayerQTEScript player = collision.gameObject.GetComponent<PlayerQTEScript>();
           if(player != null)
           {
               player.StartGame();
           }
        }
    }
}
