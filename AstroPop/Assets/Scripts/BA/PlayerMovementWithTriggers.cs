using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWTigger: MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    private Vector2 movement;
   

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;


        Triggers();

    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
    }

    public void Triggers()
    {
        /*
        Debug.Log(rb.velocity.x);
        if (rb.velocity.x > 0.1)
        {
            animator.SetBool("IsMoving", true);
            Debug.Log("1");
        }
        
        if (rb.velocity.x < 0.1)
        {
            animator.SetBool("IsMoving", false);
            Debug.Log("2");
        }
        */


        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsMoving", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsMoving", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsMoving", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsMoving", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsMoving", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsMoving", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsMoving", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsMoving", false);
        }






        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsInteracting", true);
        }
        else
        {
            animator.SetBool("IsInteracting", false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("IsCollecting", true);
        }
        else
        {
            animator.SetBool("IsCollecting", false);
        }
    }
}

    

