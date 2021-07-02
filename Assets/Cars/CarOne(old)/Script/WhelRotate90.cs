using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhelRotate90 : MonoBehaviour
{
    // Start is called before the first frame update
    public WheelCollider wheelCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);


        transform.position = position;


        transform.rotation = rotation;

        transform.Rotate(0, 0, 90, Space.Self);

    }
}
