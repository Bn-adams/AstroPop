using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Reference to the HUD Canvas GameObject
    public GameObject interactionHUD;

    // Flag to track if the player is in range of an interactable object
    private bool isInteractableInRange = false;

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Interactable" tag
        if (other.CompareTag("Interactable"))
        {
            isInteractableInRange = true;

            // Make the HUD visible if it's assigned
            if (interactionHUD != null)
            {
                interactionHUD.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the "Interactable" area
        if (other.CompareTag("Interactable"))
        {
            isInteractableInRange = false;

            // Hide the HUD if it's assigned
            if (interactionHUD != null)
            {
                interactionHUD.SetActive(false);
            }
        }
    }

    void InteractQ()
    {
        // Placeholder function for the interaction logic
        Debug.Log("Interact Q button pressed.");
    }
    void InteractE()
    {
        // Placeholder function for the interaction logic
        Debug.Log("Interact E button pressed.");
    }
}
