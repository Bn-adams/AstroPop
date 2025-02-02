using System.Collections;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [Header("Scripts Ref:")] public GrapplingRope grappleRope;


    [Header("Layers Settings:")] [SerializeField]
    private bool grappleToAll = false;

    [SerializeField] private int grappableLayerNumber = 9;

    [Header("Main Camera:")] public Camera m_camera;

    [Header("Transform Ref:")] public Transform gunHolder;
    public Transform gunPivot;
    public Transform firePoint;



    [Header("Physics Ref:")] public SpringJoint2D m_springJoint2D;
    public Rigidbody2D m_rigidbody;

    [Header("Rotation:")] [SerializeField] private bool rotateOverTime = true;
    [Range(0, 60)] [SerializeField] private float rotationSpeed = 4;

    [Header("Distance:")] [SerializeField] private bool hasMaxDistance = false;
    [SerializeField] private float maxDistnace = 20;

    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }

    [Header("Launching:")] [SerializeField]
    private bool launchToPoint = true;

    [SerializeField] private LaunchType launchType = LaunchType.Physics_Launch;
    [SerializeField] private float launchSpeed = 1;

    [Header("No Launch To Point")] [SerializeField]
    private bool autoConfigureDistance = false;

    [SerializeField] private float targetDistance = 3;
    [SerializeField] private float targetFrequncy = 1;

    [Header("RopeLength:")] [SerializeField]
    private float minimumRopeDistance;

    [SerializeField] private float maximumRopeDistance;

    [HideInInspector] public Vector2 grapplePoint;
    [HideInInspector] public Vector2 grappleDistanceVector;

    [Header("Debug:")] [SerializeField] private bool debug = false;
    [SerializeField] private bool ropeElasticity = true;
    [SerializeField] private float elasticityModifier = 0.2f;
    [SerializeField] private bool ropeExtraMomentum = true;
    [Range(-10, 0)] [SerializeField] private float ropeDeceleration = 1f;

    [SerializeField] private bool constantRopeReel = false; 


    private void Start()
    {
        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;

    }
    bool ToGrapple;
    private bool hasReeled;
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
                ToGrapple = true;
                hasReeled = true;
            }

            if (Input.GetAxisRaw("Vertical") > 0 && m_springJoint2D.distance > minimumRopeDistance)
            {
                m_springJoint2D.distance -= 5 * Time.deltaTime;
                ToGrapple = false;
                hasReeled = true;
            }
        }

        if (hasReeled && grappleRope.enabled == false)
        {
            GrapplePullVelocity(ToGrapple);
            hasReeled = false;
        }
    }

    void GrapplePullVelocity(bool towards)
    {
        Vector2 velocity;
        Vector2 grappleDirection = (grapplePoint - (Vector2)transform.position).normalized;

        if (towards)
        {
            velocity = -5 * grappleDirection;
        }
        else
        {
            velocity = 5 * grappleDirection;
        }
        m_rigidbody.AddForce(velocity*10,ForceMode2D.Force);
        Debug.Log("Grapple pull velocity: " + velocity); 
        
    }
    
    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - gunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotateOverTime && allowRotationOverTime)
        {
            gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward),
                Time.deltaTime * rotationSpeed);

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
        // Recoil();
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
            if (ropeExtraMomentum)
            {
                GrappleDirectionalVelocity();
            }

            if (ropeElasticity)
            {
                StopAllCoroutines();
                StartCoroutine(AdjustGrappleDistance());
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
        if (debug)
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
        Vector2 grappleDirection = (grapplePoint - (Vector2)transform.position).normalized;
        Vector2 velocity = m_rigidbody.velocity;
        m_rigidbody.AddForce(velocity * 10);
    }


    [SerializeField] float grappleSpeed;
    [SerializeField] float dotValue;

    [SerializeField] private bool extraRope;

    [SerializeField] float ropelength;
    private IEnumerator AdjustGrappleDistance( )
    {
        Vector2 velocity = m_rigidbody.velocity; 
        Vector2 grappleDirection = (grapplePoint - (Vector2)transform.position).normalized;

        dotValue = Vector2.Dot(velocity.normalized, grappleDirection);
        grappleSpeed = velocity.magnitude * dotValue;
        
        if (grappleSpeed > 0)
        {
            while (grappleSpeed > 1f && grappleRope.enabled)
            {

                grappleSpeed = grappleSpeed + ropeDeceleration*Time.deltaTime;
                
                ropelength = Mathf.Clamp(m_springJoint2D.distance - grappleSpeed * Time.deltaTime,minimumRopeDistance,maximumRopeDistance);
                m_springJoint2D.distance = ropelength;
                if (ropelength == minimumRopeDistance)
                {
                    yield break;
                }
                yield return null;
            }


        }
        else if(grappleSpeed < 0 && !constantRopeReel && extraRope)
        {
            while (grappleSpeed < -1f && grappleRope.enabled )
            {

                grappleSpeed = grappleSpeed - ropeDeceleration*Time.deltaTime;
                


                ropelength = Mathf.Clamp(m_springJoint2D.distance - grappleSpeed * Time.deltaTime,minimumRopeDistance,maximumRopeDistance);
                m_springJoint2D.distance = ropelength;
                if (ropelength == maximumRopeDistance)
                {
                    yield break;
                }
                yield return null;
            }
        }
        else if (grappleSpeed == 0 || !extraRope)
        {
            yield break;
        }
        else
        {
            grappleSpeed = 5;
            float ropeAcceleration = 1;
            while (grappleRope.enabled)
            {

                grappleSpeed = grappleSpeed + ropeAcceleration*Time.deltaTime;
                
                ropelength = Mathf.Clamp(m_springJoint2D.distance - grappleSpeed * Time.deltaTime,minimumRopeDistance,maximumRopeDistance);
                m_springJoint2D.distance = ropelength;
                yield return null;
            }
           // velocity = grappleDirection.normalized * grappleSpeed;
           // m_rigidbody.velocity = velocity;
        }
       
    }

     public void BreakGrapple()
    {
        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;
    }
   
}