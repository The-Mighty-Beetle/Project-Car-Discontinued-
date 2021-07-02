using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraControl : MonoBehaviour
{
    [Tooltip("Car to be followed.")]
    public Transform TargetObject;
    [Tooltip("Difference from the car.")]
    public Vector3 Offset;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(TargetObject);
        transform.position = TargetObject.position-Offset;
        
    }
}
