using System;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Installers
{
    [CreateAssetMenu(fileName = "Preview Camera Settings", menuName = "Scene_2_Hangar/Preview Camera Settings")]
    public class PreviewCameraSettings : ScriptableObjectInstaller<PreviewCameraSettings>
    {
        public Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }

        [Serializable]
        public class Settings
        {
            [Header("Rotation")]
            public float MinAngleX;
            public float MaxAngleX;

            [Header("Zoom")]
            public float ZoomSpeed;
            public float MinLocalPositionZ;
            public float MaxLocalPositionZ;
        }
    }
}