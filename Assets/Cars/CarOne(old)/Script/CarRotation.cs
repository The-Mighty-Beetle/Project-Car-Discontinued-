using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = transform.rotation.z;

        if (transform.rotation.z == 90 || transform.rotation.z == -90 || 
            transform.rotation.z == 180 || transform.rotation.z == -180||
            transform.rotation.x == 90 || transform.rotation.x == -90 ||
            transform.rotation.x == 180 || transform.rotation.x == -180)
        {
            
            transform.Rotate(0, 0, 0, Space.Self);


        }
        
    }
}
