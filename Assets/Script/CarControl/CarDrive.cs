using Assets.Script.CarControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    public static void Move(AxleInfo frontAxle,AxleInfo rearAxle,float torque)
    {
        if(frontAxle.motor)
        {
            frontAxle.leftWheel.motorTorque = torque;
            frontAxle.rightWheel.motorTorque = torque;
        }

        if(rearAxle.motor)
        {
            rearAxle.leftWheel.motorTorque = torque;
            rearAxle.rightWheel.motorTorque = torque;

        }

    }
    public static void Steraring(AxleInfo frontAxle,AxleInfo rearAxle,float stearingAngle)
    {
        if(frontAxle.steering)
        {
            frontAxle.leftWheel.steerAngle = stearingAngle;
            frontAxle.rightWheel.steerAngle = stearingAngle;

            //frontAxle.leftWheel.steerAngle = Mathf.LerpAngle(0, stearingAngle, .01f); //stearingAngle;
            //frontAxle.rightWheel.steerAngle = Mathf.LerpAngle(0, stearingAngle,.01f);

        }

        if(rearAxle.steering)
        {
            rearAxle.leftWheel.steerAngle = stearingAngle;
            rearAxle.rightWheel.steerAngle = stearingAngle;

            //rearAxle.leftWheel.steerAngle = Mathf.LerpAngle(0, stearingAngle,.01f);
            //rearAxle.rightWheel.steerAngle = Mathf.LerpAngle(0, stearingAngle,.01f);
        }

    }
    public static void Break(AxleInfo frontAxle,AxleInfo rearAxle,float breakTorque)
    {
        frontAxle.leftWheel.brakeTorque = breakTorque;
        frontAxle.rightWheel.brakeTorque = breakTorque;

        rearAxle.leftWheel.brakeTorque = breakTorque;
        rearAxle.rightWheel.brakeTorque = breakTorque;

    }

    public static void SetAxleMotor(AxleInfo frontAxle, AxleInfo rearAxle, AllModes driveMode)
    {
        if (driveMode == AllModes.Front)
        {
            frontAxle.motor = true;
            rearAxle.motor = false;
        }

        else if (driveMode == AllModes.Rear)
        {
            frontAxle.motor = false;
            rearAxle.motor = true;
        }
        else
        {
            frontAxle.motor = true;
            rearAxle.motor = true;

        }
    }

}
