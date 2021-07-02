using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
    public float IdealSpeed = 50f;
    public float MaxSpeed = 500f;
    public float BackForce = 4;

    public WheelCollider Frt;
    public WheelCollider Flt;
    public WheelCollider Rrt;
    public WheelCollider Rlt;

    public Text SpeedText;

    //[Range(1f,100f)]
    public float WheelRotation = 30f;

    public float Torque = 100f;
    public float BreaKTorque = 100f;

    [Tooltip("The vehicle's speed when the physics engine can use different amount of sub-steps (in m/s).")]
    public float criticalSpeed = 5f;
    [Tooltip("Simulation sub-steps when the speed is above critical.")]
    public int stepsBelow = 5;
    [Tooltip("Simulation sub-steps when the speed is below critical.")]
    public int stepsAbove = 1;

    //public float scaledTorque;

    public Transform CenterOfMass;

    public enum DriveMode { Front, Rear, All };

    public DriveMode driveMode = DriveMode.Rear;

    private void Start()
    {
        BreaKTorque = Torque * 10;

        Rigidbody carBody = GetComponent<Rigidbody>();

        carBody.centerOfMass = CenterOfMass.localPosition;
    }

    // Update is called once per frame    
    private void FixedUpdate()
    {
        //Frt.ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);

        float scaledTorque = Input.GetAxis("Vertical") * Torque;

        

        if (scaledTorque >= MaxSpeed)
        {
            scaledTorque = MaxSpeed;
        }
        //else
        //{
        //    scaledTorque *= Torque;
        //}

        


        Frt.steerAngle = Input.GetAxis("Horizontal") * WheelRotation;
        Flt.steerAngle = Input.GetAxis("Horizontal") * WheelRotation;

        if (driveMode == DriveMode.Rear)
        {
            Frt.motorTorque = 0;
            Flt.motorTorque = 0;
            Rrt.motorTorque = scaledTorque;
            Rlt.motorTorque = scaledTorque;
        }
        else if (driveMode == DriveMode.Front)
        {
            Frt.motorTorque = scaledTorque;
            Flt.motorTorque = scaledTorque;
            Rrt.motorTorque = 0;
            Rlt.motorTorque = 0;
        }
        else if(driveMode == DriveMode.All)
        {
            Frt.motorTorque = scaledTorque;
            Flt.motorTorque = scaledTorque;
            Rrt.motorTorque = scaledTorque;
            Rlt.motorTorque = scaledTorque;

        }

        if (Input.GetButton("Jump"))
        {
            Frt.brakeTorque = BreaKTorque;
            Flt.brakeTorque = BreaKTorque;
            Rrt.brakeTorque = BreaKTorque;
            Rlt.brakeTorque = BreaKTorque;
        }
        else
        {
            Frt.brakeTorque = 0;
            Flt.brakeTorque = 0;
            Rrt.brakeTorque = 0;
            Rlt.brakeTorque = 0;
        }

        Debug.Log(scaledTorque);
    }
}
