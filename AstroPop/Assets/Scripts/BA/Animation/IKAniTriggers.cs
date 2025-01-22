using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAniTriggers : MonoBehaviour
{
    private Animator IKanimator;
    public Rigidbody2D PlayerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        IKanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
        if (Input.GetKeyUp(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {
            IKanimator.SetTrigger("Walk2RIdle");
        }



        /*
        if (PlayerRigidbody.velocity.magnitude <= 0.01)
        {
            IKanimator.SetTrigger("Idle2WalkR");

        }
        */
    }
}


