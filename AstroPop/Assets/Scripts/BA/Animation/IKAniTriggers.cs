using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAniTriggers : MonoBehaviour
{
    private Animator IKanimator;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        IKanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        Debug.Log(rb.velocity.x);

        if(rb.velocity.x > 0.1)
        {
            IKanimator.SetBool("IsMoving", true);
            Debug.Log("1");
        }
        /*
        if (rb.velocity.x < 0.1)
        {
            IKanimator.SetBool("IsMoving", false);
            Debug.Log("2");
        }
        */


        if (Input.GetKeyDown(KeyCode.E))
        {
            IKanimator.SetBool("IsInteracting", true);
        }
        else
        {
            IKanimator.SetBool("IsInteracting", false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IKanimator.SetBool("IsCollecting", true);
        }
        else
        {
            IKanimator.SetBool("IsCollecting", false);
        }
    }




        /*
       
       
                if (PlayerRigidbody.velocity.magnitude <= 0.01)
        {
            IKanimator.SetTrigger("Walk2RIdle");

        }


         if (Input.GetKeyDown(KeyCode.W))
        {

        }
        if (Input.GetKeyUp(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.D)) 
        {
            IKanimator.SetTrigger("Idle2WalkR");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            IKanimator.SetTrigger("Walk2RIdle");
        }


    
        */
   
}


