using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTriggers : MonoBehaviour
{
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("WalkingR");
            Debug.Log("U smell");

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetTrigger("Back2RIdle");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("WalkingL");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetTrigger("Back2LIdle");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WalkingU");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetTrigger("Back2RIdle");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("WalkingD");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetTrigger("Back2LIdle");
        }
    }
}

    

