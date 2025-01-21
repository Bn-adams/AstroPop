using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    // Reference to the HUD Canvas GameObject
    public GameObject interactionHUD;

    IInteractable interactable;

    // Flag to track if the player is in range of an interactable object
    private bool isInteractableInRange = false;
    private bool QButtonDown = false;
    private bool EButtonDown = false;
    void Start()
    {
        // Ensure the HUD is initially hidden if it's assigned
        if (interactionHUD != null)
        {
            interactionHUD.SetActive(false);
        }
        else
        {
            Debug.LogError("Assign the HUD in the inspector :)");
        }
    }

    void Update()
    {
        // Check for the 'E' key press and call a function if the player is in range
        if (isInteractableInRange && Input.GetKeyDown(KeyCode.Q))
        {
            InteractQ();
        }
        if (isInteractableInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractE();
        }
        //if (Input.GetKeyDown(KeyCode.Q)) QButtonDown = true;
        //if (Input.GetKeyUp(KeyCode.Q)) QButtonDown = false;

        //if (Input.GetKeyDown(KeyCode.E)) EButtonDown = true;
        //if (Input.GetKeyUp(KeyCode.E)) EButtonDown = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Interactable" tag
        if (collision.CompareTag("Interactable"))
        {
            // Makes the variable "interactable" be assigned to the current object your near
            interactable = collision.GetComponent<IInteractable>();


            isInteractableInRange = true;

            // Make the HUD visible if it's assigned
            if (interactionHUD != null)
            {
                interactionHUD.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player exits the "Interactable" area
        if (collision.CompareTag("Interactable"))
        {
            isInteractableInRange = false;

            // Hide the HUD if it's assigned
            if (interactionHUD != null)
            {
                interactionHUD.SetActive(false);
            }
        }
    }

    // Interactions
    void InteractQ()
    {
        if (interactable != null && isInteractableInRange)
        {
            interactable.InteractQ();
        }
    }
    void InteractE()
    {
        if (interactable != null && isInteractableInRange)
        {
            interactable.InteractE();
        }
    }
}
