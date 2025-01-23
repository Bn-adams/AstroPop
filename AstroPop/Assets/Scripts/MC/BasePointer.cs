using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePointer : MonoBehaviour
{
    public Transform targetTransform;
    private Vector2 targetPosition;
    private Transform pointerRectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        targetPosition = new Vector3(0,0);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        Vector3 direction = (toPosition - fromPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        pointerRectTransform.rotation =  Quaternion.Euler(0, 0, angle);
        
     
    }
}
