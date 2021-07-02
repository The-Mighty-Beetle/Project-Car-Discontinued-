using Assets.Script.CarControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOneController : MonoBehaviour
{
    public CarSpeed speeds;
    public AxleInfo frontAxle;
    public AxleInfo rearAxle;

    public Transform CenterOfMass;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody carBody = GetComponent<Rigidbody>();
        carBody.centerOfMass = CenterOfMass.localPosition;
        CarDrive.SetAxleMotor(frontAxle, rearAxle, speeds.DriveMode);

    }

    // Update is called once per frame
    void Update()
    {
        float ScaledTorque = Input.GetAxis("Vertical") * speeds.Torque;
        float StearingAngle = Input.GetAxis("Horizontal") * speeds.StearingAngle;

        if (ScaledTorque > speeds.MaxSpeed)
        {
            ScaledTorque = speeds.MaxSpeed;
        }

        CarDrive.Move(frontAxle, rearAxle, ScaledTorque);
        CarDrive.Steraring(frontAxle, rearAxle, StearingAngle);

        if (Input.GetButton("Jump"))
        {
            CarDrive.Break(frontAxle, rearAxle, speeds.BreakForce);
        }


    }
}
