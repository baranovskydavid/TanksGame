using System;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Installers
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "Scene_3_Battlefield/CameraSettings")]
    public class PlayerCameraSettings : ScriptableObjectInstaller<PlayerCameraSettings>
    {
        public Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }

        [Serializable]
        public class Settings
        {
            public GameObject Prefab;

            [Header("Move Settings")] 
            public float MovingSpeed;

            [Header("EulerAngles Settings")]
            public float MinAngleX;
            public float MaxAngleX;

            [Header("Zoom Settings")] 
            public float ZoomingSpeed;
            public int DefaultOffsetId;
            public Vector3[] Offsets;

            [Header("Hit Point Settings")] 
            public float DefaultDistanceToHitPoint;
        }
    }
}