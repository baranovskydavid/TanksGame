using System;
using UnityEngine;

namespace Common.Scripts.Installers
{
    [CreateAssetMenu(fileName = "Tank Settings", menuName = "Common/Tank Settings")]
    public class TankSettings : ScriptableObject
    {
        public MainInfo MainInfo;
        public Motor Motor;
        public Turret Turret;
        public Trunk Trunk;
    }

    [Serializable]
    public class MainInfo
    {
        public int Level;
        public string Name;
        public Sprite Preview;
        public GameObject PhysicTank;
    }

    [Serializable]
    public class Motor
    {
        public float MotorTorque;
        public float BrakeTorque;
        public float MaxForwardSpeed;
        public float MaxBackwardSpeed;
        
        public float RotationSpeed;
        public float RotationAtPlaceSpeed;
    }

    [Serializable]
    public class Turret
    {
        public float RotationSpeed;
    }

    [Serializable]
    public class Trunk
    {
        public Shell[] Shells;
        
        [Header("Rotation Settings")]
        public float RotationSpeed;
        public float MinAngle;
        public float MaxAngle;
    }

    [Serializable]
    public class Shell
    {
        public ShellType ShellType;
        public int Penetration;
        public int Damage;
    }
}
    