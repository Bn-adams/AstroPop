using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [Header("Swing Settings")]
    public float maxSwingDistance = 10f; // Maximum distance for raycast

    private DistanceJoint2D swingJoint; // The joint used for swinging
    private Rigidbody2D playerRigidbody; // Player's Rigidbody2D

    private HingeJoint2D hingeJoint;
    private LineRenderer ropeRenderer;

    void Start()
    {
        // Initialize player Rigidbody2D
        playerRigidbody = GetComponent<Rigidbody2D>();

        // Add a DistanceJoint2D but disable it initially
        swingJoint = gameObject.AddComponent<DistanceJoint2D>();
        swingJoint.enabled = false;
        swingJoint.autoConfigureDistance = false; // Distance will be set manually


        ropeRenderer = gameObject.AddComponent<LineRenderer>();
        ropeRenderer.startWidth = 0.1f;
        ropeRenderer.endWidth = 0.1f;
        ropeRenderer.positionCount = 2; // Two points (player and anchor)
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TrySwing();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ReleaseSwing();
        }
    }

    private void TrySwing()
    {
        // Cast a ray from the player's position towards the mouse position
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayDirection = (mouseWorldPosition - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, maxSwingDistance);

        if (hit.collider != null)
        {
            // Attach the joint to the hit point
            swingJoint.enabled = true;
            swingJoint.connectedBody = hit.collider.attachedRigidbody; // Connect to the asteroid's Rigidbody2D
            swingJoint.connectedAnchor = hit.point; // Connect to the point where the raycast hit
            swingJoint.distance = Vector2.Distance(transform.position, hit.point); // Set the swing distance
        }
    }

    private void ReleaseSwing()
    {
        // Disable the joint to release the swing
        if (swingJoint.enabled)
        {
            swingJoint.enabled = false;
        }
    }

    void UpdateRopeVisual()
    {
        // Update the rope visual by setting the positions of the LineRenderer
        if (ropeRenderer != null)
        {
            ropeRenderer.SetPosition(0, transform.position); // Player position
            ropeRenderer.SetPosition(1, GetComponent<HingeJoint>().connectedAnchor); // Anchor position
        }
    }
}
