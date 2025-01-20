using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PExploreMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxSpeed = 10f;
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
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        rb.AddForce(movement * moveSpeed, ForceMode2D.Force);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
