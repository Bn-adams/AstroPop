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
    //[SerializeField] bool ReversedGrapple;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float speed;
    [SerializeField] private bool nonClockwiseMovement;
    // Start is called before the first frame update
    void Start()
    {
      rb =  GetComponent<Rigidbody2D>();

    }
    [SerializeField]   bool isInput;
    [SerializeField] bool ReversedGrapple;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
       // movement.y = Input.GetAxisRaw("Vertical");
     
        isInput = movement.x != 0;
        movement = movement.normalized;
        if(nonClockwiseMovement){
            if (gunPivot.rotation.z < 0 && !isGrappling )
            {
                ReversedGrapple = true;
            }
            else if (gunPivot.rotation.z > 0 && !isGrappling )
            {
                ReversedGrapple = false;
            }

            if (ReversedGrapple )
            {
                movement.x = -movement.x;
            }
        }
        
        velocity = rb.velocity;
        speed=rb.velocity.magnitude;
    }
   
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (isGrappling)
        {
            
            
            if(gunPivot.rotation.z < 0) 
            { 
                movement.x = -movement.x; 
            }
            rb.AddForce(movement * moveSpeed, ForceMode2D.Force);
            
            
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
