using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform TargetObject;
    public Vector3 Offset;
    public float FollowSpeed = 10f;
    public float LookSpeed = 10f;

    public void LookAtTarget()
    {
        Vector3 lookDirection = TargetObject.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);


        

        transform.rotation = Quaternion.Lerp(transform.rotation, rot,
                                             LookSpeed * Time.deltaTime);
        //transform.Rotate(0, 0, 90, Space.Self);


    }

    public void MoveToTarget()
    {
        Vector3 targetPosition = TargetObject.position +
                                 TargetObject.forward * Offset.z +
                                 TargetObject.right * Offset.x +
                                 TargetObject.up * Offset.y;

        transform.position = Vector3.Lerp(transform.position, targetPosition,
                                           FollowSpeed * Time.deltaTime);


    }


    public void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
