using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    public Animator animator;
    public BoxCollider2D BoxCollider2D;
   
    public void Start()
    {
        animator = GetComponent<Animator>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void InteractQ()
    {
        Debug.Log("u smell");
    }
    public void InteractE()
    {
        Debug.Log(" U suck");
        StartCoroutine(DoorCoroutine());
        BoxCollider2D.enabled = false;
        

    }

    IEnumerator DoorCoroutine()
    {
        animator.SetBool("IsOpening", true);
        yield return new WaitForSeconds(1);

        animator.SetBool("IsOpening", false);
        yield return new WaitForSeconds(1f);

       
        animator.SetBool("IsClosing", true);
        yield return new WaitForSeconds(1);

        animator.SetBool("IsClosing", false);
        yield return new WaitForSeconds(1);

        

        BoxCollider2D.enabled = true;

        yield break;
    }
}

