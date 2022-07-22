using System;
using Common.Scripts.Installers;
using Scenes.Scene_3_Battlefield.Scripts.Views;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Models
{
    public class PlayerTankModel
    {
        public TankView TankView;
        public PlayerCameraView PlayerCameraView;
        public TankSettings Settings;

        public MotorInfo MotorInfo;
        
        public WheelsCollidersData LeftWheelsCollidersData = new WheelsCollidersData();
        public WheelsCollidersData RightWheelsCollidersData = new WheelsCollidersData();
        
        public Quaternion Rotation = Quaternion.Euler(Vector3.zero);

        public Vector3 CameraHitPointPosition;
        public int CameraHitPointDistance;
        public Vector3 TrunkHitPointPosition;
        public Vector3 TrunkHitPointUiPosition;
    }
    
    //DEBUG
    [Serializable]
    public class MotorInfo
    {
        public float AverageSpeed;
        
        public float AverageLeftMotorTorque;
        public float AverageLeftBrakeTorque;
        public float AverageLeftRpm;
        public float AverageLeftSpeed; 

        public float AverageRightMotorTorque;
        public float AverageRightBrakeTorque;
        public float AverageRightRpm;
        public float AverageRightSpeed;
    }

    public class WheelsCollidersData
    {
        public float MotorTorque;
        public float BrakeTorque;
        
        public void ChangeWheelColliderData(float motorTorque = 0f, float brakeTorque = 0f)
        {
            MotorTorque = motorTorque;
            BrakeTorque = brakeTorque;
        }
    }

}