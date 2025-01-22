using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component attached to the character
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check for horizontal input (left and right arrow keys or A/D)
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            // Flip the sprite based on the movement direction
            FlipSprite(moveInput);
        }
    }

    void FlipSprite(float moveInput)
    {
        // If moving right, set scale to positive; if moving left, set scale to negative
        if (moveInput > 0)
        {
            // Facing right: normal scale
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveInput < 0)
        {
            // Facing left: flip the scale on the x-axis
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
   
        
    
  


