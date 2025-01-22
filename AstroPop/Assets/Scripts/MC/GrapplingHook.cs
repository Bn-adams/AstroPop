using System.Collections;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [Header("Scripts Ref:")]
    public GrapplingRope grappleRope;
    

    [Header("Layers Settings:")]
    [SerializeField] private bool grappleToAll = false;
    [SerializeField] private int grappableLayerNumber = 9;

    [Header("Main Camera:")]
    public Camera m_camera;

    [Header("Transform Ref:")]
    public Transform gunHolder;
    public Transform gunPivot;
    public Transform firePoint;
    
    

    [Header("Physics Ref:")]
    public SpringJoint2D m_springJoint2D;
    public Rigidbody2D m_rigidbody;

    [Header("Rotation:")]
    [SerializeField] private bool rotateOverTime = true;
    [Range(0, 60)][SerializeField] private float rotationSpeed = 4;

    [Header("Distance:")]
    [SerializeField] private bool hasMaxDistance = false;
    [SerializeField] private float maxDistnace = 20;

    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }

    [Header("Launching:")]
    [SerializeField] private bool launchToPoint = true;
    [SerializeField] private LaunchType launchType = LaunchType.Physics_Launch;
    [SerializeField] private float launchSpeed = 1;

    [Header("No Launch To Point")]
    [SerializeField] private bool autoConfigureDistance = false;
    [SerializeField] private float targetDistance = 3;
    [SerializeField] private float targetFrequncy = 1;

    [Header("RopeLength:")]
    [SerializeField] private float minimumRopeDistance;
    [SerializeField] private float maximumRopeDistance;

    [HideInInspector] public Vector2 grapplePoint;
    [HideInInspector] public Vector2 grappleDistanceVector;
    
    [Header("Debug:")]
    [SerializeField] private bool debug = false;
    [SerializeField] private bool ropeElasticity = true;
    [SerializeField] private float elasticityModifier = 0.2f;
    [SerializeField] private bool ropeExtraMomentum = true;
    private void Start()
    {
        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetGrapplePoint();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            if (grappleRope.enabled)
            {
                RotateGun(grapplePoint, false);
            }
            else
            {
                Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
                RotateGun(mousePos, true);
            }

            if (launchToPoint && grappleRope.isGrappling)
            {
                if (launchType == LaunchType.Transform_Launch)
                {
                    Vector2 firePointDistnace = firePoint.position - gunHolder.localPosition;
                    Vector2 targetPos = grapplePoint - firePointDistnace;
                    gunHolder.position = Vector2.Lerp(gunHolder.position, targetPos, Time.deltaTime * launchSpeed);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            grappleRope.enabled = false;
            m_springJoint2D.enabled = false;
           // m_rigidbody.gravityScale = 1;
        }
        else
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            RotateGun(mousePos, true);
        }

        if (grappleRope.enabled) 
        {
            if (Input.GetAxisRaw("Vertical") < 0 && m_springJoint2D.distance < maximumRopeDistance)
            {
                m_springJoint2D.distance += 5 * Time.deltaTime;
            }
            if(Input.GetAxisRaw("Vertical") > 0 && m_springJoint2D.distance >minimumRopeDistance)
            {
                m_springJoint2D.distance -= 5 * Time.deltaTime;
            }
        }
    }

    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - gunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotateOverTime && allowRotationOverTime)
        {
            gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
            
        }
        else
        {
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
        }
    }

    void SetGrapplePoint()
    {
        Vector2 distanceVector = m_camera.ScreenToWorldPoint(Input.mousePosition) - gunPivot.position;
        if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
        {
            RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector.normalized);
            if (_hit.transform.gameObject.layer == grappableLayerNumber || grappleToAll)
            {
                if (Vector2.Distance(_hit.point, firePoint.position) <= maxDistnace || !hasMaxDistance)
                {
                    grapplePoint = _hit.transform.position;
                    grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
                    grappleRope.enabled = true;
                }
            }
        }
    }

    public void Grapple()
    {
        m_springJoint2D.autoConfigureDistance = false;
        if (!launchToPoint && !autoConfigureDistance)
        {
           
            m_springJoint2D.distance = targetDistance;
            m_springJoint2D.frequency = targetFrequncy;
        }
        if (!launchToPoint)
        {
            if (autoConfigureDistance)
            {
                m_springJoint2D.autoConfigureDistance = true;
                m_springJoint2D.frequency = 0;
            }

            m_springJoint2D.connectedAnchor = grapplePoint;
            m_springJoint2D.enabled = true;
            if(ropeExtraMomentum)
            {
                GrappleDirectionalVelocity();
            }
            if (ropeElasticity)
            {
                SetGrappleElasticity();
            }
          
        }
        else
        {
            switch (launchType)
            {
                case LaunchType.Physics_Launch:
                    m_springJoint2D.connectedAnchor = grapplePoint;

                    Vector2 distanceVector = firePoint.position - gunHolder.position;

                    m_springJoint2D.distance = distanceVector.magnitude;
                    m_springJoint2D.frequency = launchSpeed;
                    m_springJoint2D.enabled = true;
                    break;
                case LaunchType.Transform_Launch:
                   // m_rigidbody.gravityScale = 0;
                    m_rigidbody.velocity = Vector2.zero;
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(debug)
        {
            if (firePoint != null && hasMaxDistance)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(firePoint.position, maxDistnace);
            }
        }
    }

    private void GrappleDirectionalVelocity()
    {
        Vector2 velocity = m_rigidbody.velocity;
        m_rigidbody.AddForce(velocity * 7); 
    }

   
    
    private void SetGrappleElasticity()
    {
        Vector2 velocity = m_rigidbody.velocity;
        Vector2 grappleDirection = (grapplePoint - (Vector2)transform.position).normalized;

        // Determine if moving toward or away from the grapple point
        bool isFacing = Vector2.Dot(velocity.normalized, grappleDirection) > 0;

        // Calculate elasticity value based on velocity
        // Adjust multiplier for desired effect
        if(velocity.magnitude>10)
        {
            float elasticityValue = velocity.magnitude * elasticityModifier; 
            // Stop any existing coroutine to prevent stacking
            StopAllCoroutines();
            StartCoroutine(AdjustGrappleDistance(isFacing, elasticityValue));
        }
    }

    private IEnumerator AdjustGrappleDistance(bool isFacing, float elasticityValue)
    {
        float duration = 1.5f; // Time over which to adjust the distance
        float elapsed = 0;

        float initialDistance = m_springJoint2D.distance;
        float targetdistance;
        
        if(isFacing)
        {
            targetdistance = Mathf.Max(initialDistance - elasticityValue, 2f); // Decrease distance smoothly
            
        }
        else
        {
            targetdistance = Mathf.Min(initialDistance + elasticityValue, maximumRopeDistance); // Increase distance smoothly
         
        }

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
          
            // Interpolate the distance with a smoother easing function
            m_springJoint2D.distance = Mathf.Lerp(initialDistance, targetdistance, Mathf.SmoothStep(0, 1, t));
            
            yield return null; // Wait for the next frame
        }

        // Final adjustment to ensure accuracy
        m_springJoint2D.distance = targetdistance;
       
    }
}
