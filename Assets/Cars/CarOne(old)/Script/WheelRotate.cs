using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    public WheelCollider wheelCollider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);


        //transform.position = position;


        transform.rotation = rotation;

        //transform.Rotate(0, 0, 90, Space.Self);


    }
}
