using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float MoveX;
    public float MoveY;

    public float LocalScaleX;

    void Start()
    {
        // Get the SpriteRenderer component attached to the character
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        LocalScaleX = transform.localScale.x;
        // Check for horizontal input (left and right arrow keys or A/D)
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");

        if (MoveX != 0)
        {
            // Flip the sprite based on the movement direction
            FlipSpriteX(MoveX);

        }
        if (MoveY != 0)
        {
            // Flip the sprite based on the movement direction
            FlipSpriteY(MoveY);

        }
    }

    void FlipSpriteX(float MoveX)
    {
        // If moving right, set scale to positive; if moving left, set scale to negative
        if (MoveX > 0)
        {
            // Facing right: normal scale
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (MoveX < 0)
        {
            // Facing left: flip the scale on the x-axis
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void FlipSpriteY(float MoveY )
    {
        // If moving right, set scale to positive; if moving left, set scale to negative
        if (LocalScaleX < 1 && MoveX == 0  &&  MoveY > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        else if (LocalScaleX > -1 && MoveX == 0 && MoveY < 0)
        {
            // Facing left: flip the scale on the x-axis
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
   
        
    
  


