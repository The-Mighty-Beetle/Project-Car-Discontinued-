using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//public enum DriveType
//{
//    RearWheelDrive,
//    FrontWheelDrive,
//    AllWheelDrive
//}

public class TestControl : MonoBehaviour
{
	[Tooltip("Maximum steering angle of the wheels")]
	public float maxAngle = 30f;
	[Tooltip("Maximum torque applied to the driving wheels")]
	public float maxTorque = 300f;
	[Tooltip("Maximum brake torque applied to the driving wheels")]
	public float brakeTorque = 30000f;
	[Tooltip("If you need the visual wheels to be attached automatically, drag the wheel shape here.")]
	public GameObject wheelShape;

	[Tooltip("The vehicle's speed when the physics engine can use different amount of sub-steps (in m/s).")]
	public float criticalSpeed = 5f;
	[Tooltip("Simulation sub-steps when the speed is above critical.")]
	public int stepsBelow = 5;
	[Tooltip("Simulation sub-steps when the speed is below critical.")]
	public int stepsAbove = 1;

	//[Tooltip("The vehicle's drive type: rear-wheels drive, front-wheels drive or all-wheels drive.")]

	public WheelCollider Frt;
	public WheelCollider Flt;
	public WheelCollider Rrt;
	public WheelCollider Rlt;


	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Frt.ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);

		float angle = maxAngle * Input.GetAxis("Horizontal");
		float torque = maxTorque * Input.GetAxis("Vertical");

	}
}
