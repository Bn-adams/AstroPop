using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamFollow : MonoBehaviour
{
    public PlayerSwitcherScript PlayerSwitcherScript;
    public Transform Target1;
    public Transform Target2;


    public Vector3 offset = new(0, 0,-10);
    public Camera targetCam;

    // Start is called before the first frame update
    void Start()
    {
        targetCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSwitcherScript.isTarget1)
        {
            transform.position = Target1.position + offset;
            targetCam.orthographicSize = 5f;
        }
        else
        {
            transform.position = Target2.position + offset;
            targetCam.orthographicSize = 15f;

        }
    }
}
