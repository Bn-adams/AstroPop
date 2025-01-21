using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PExploreMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxSpeed = 10f;
    private Vector2 movement;
    public bool isGrappling;
    public Rigidbody2D rb;
    public Transform gunPivot;
    bool ReversedGrapple;
    // Start is called before the first frame update
    void Start()
    {
      rb =  GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
       // movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
       if(gunPivot.rotation.z < 0&&!isGrappling)
        {
            ReversedGrapple = true;
        }
        else if(gunPivot.rotation.z > 0 &&!isGrappling)
        {
            ReversedGrapple = false;
        }
        if (ReversedGrapple)
        {
            movement.x = -movement.x;
        }
    }
   
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (isGrappling)
        {
            
            
            if(gunPivot.rotation.z < 0 ) 
            { 
                movement.x = -movement.x; 
            }
            rb.AddForce(movement * moveSpeed, ForceMode2D.Force);
            
            
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
