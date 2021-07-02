using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.CarControl
{
    [System.Serializable]
    public class CarSpeed
    {
        public float MaxSpeed;
        public float BreakForce;
        public float StearingAngle;
        public float Torque;
        public AllModes DriveMode;
    }

    [System.Serializable]
    public enum AllModes { Front, Rear, All };


}
