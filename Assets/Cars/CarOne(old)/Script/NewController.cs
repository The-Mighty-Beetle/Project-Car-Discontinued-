using Assets.Script.CarControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    public CarSpeed speeds;  
    public AxleInfo frontAxle;
    public AxleInfo rearAxle;

    public Transform CenterOfMass;

    void Start()
    {

        //set center of mass of the car it will help to steering 
        Rigidbody carBody = GetComponent<Rigidbody>();
        carBody.centerOfMass = CenterOfMass.localPosition;


        //set Driving mode

        CarDrive.SetAxleMotor(frontAxle, rearAxle,speeds.DriveMode);
        

        //if(speeds.DriveMode == AllModes.Front)
        //{
        //    frontAxle.motor = true;
        //    rearAxle.motor = false;
        //}

        //else if(speeds.DriveMode == AllModes.Rear)
        //{
        //    frontAxle.motor = false;
        //    rearAxle.motor = true;
        //}
        //else
        //{
        //    frontAxle.motor = true;
        //    rearAxle.motor = true;

        //}

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

        if(Input.GetButton("Jump"))
        {
            CarDrive.Break(frontAxle, rearAxle, speeds.BreakForce);
        }



    }
}
