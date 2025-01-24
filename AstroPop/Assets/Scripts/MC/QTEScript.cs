using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QTEScript : MonoBehaviour
{
    public Rigidbody rb;
    public float targetTime = 4f;
    public GameObject[] Points;
    public Slider slider;
    public bool onTarget;
    
    public PlayerQTEScript playerQTEScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up,ForceMode.Impulse);
        }
        if (onTarget)
        {
            targetTime += Time.deltaTime;
        }
        else
        {
            targetTime -= Time.deltaTime;
        }

        if (targetTime <= 0)
        {
            transform.localPosition = new Vector3(0, -0.4f, 0);
            onTarget = false;
            targetTime = 4f;
            playerQTEScript.LostGame();
        }
        else if (targetTime >= 8f)
        {
            transform.localPosition = new Vector3(0, -0.4f, 0);
            onTarget = false;
            targetTime = 4f;
            playerQTEScript.WonGame();
        }
        
        slider.value = targetTime/8f;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("QTETarget"))
        {
            onTarget = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("QTETarget"))
        {
            onTarget = false;
        }
    }
}
