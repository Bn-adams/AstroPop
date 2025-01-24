using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidZone : MonoBehaviour
{
    public float detectionRadius = 10f; // Radius within which the player is safe
    public float deathTime = 2f;       // Time outside the radius before death

    private GameObject player;         // Reference to the player object
    private float timeOutsideRadius;   // Tracks how long the player is outside the radius

    public bool showGiz;

    void Start()
    {
        // Find the player object (you can tag the player as "Player" for this to work)
        //player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("PlayerShipper");

        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Check distance between the player and the asteroid
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > detectionRadius)
        {
            // Increment the timer if the player is outside the radius
            timeOutsideRadius += Time.deltaTime;

            if (timeOutsideRadius >= deathTime)
            {
                PlayerDied();
            }
        }
        else
        {
            // Reset the timer if the player is within the radius
            timeOutsideRadius = 0f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (showGiz) showGiz = false;
              
            else showGiz = true;
        }
        
    }

    private void PlayerDied()
    {
       // Debug.Log("Player died due to leaving the safe zone!");
        // Handle player death (e.g., reload scene, reduce lives, etc.)
        // Example:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmos()
    {
        if (showGiz)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
        // Draw the detection radius in the Scene view for visualization
        
    }
}
