using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Views
{
    public class PlayerCameraView : ViewBase
    {
        public Camera Camera;

        [Header("Settings")]
        [Header("Rotation")] 
        public float MinAngleX;
        public float MaxAngleX;

        [Header("Zoom")] 
        public float ZoomingSpeed;
        public int DefaultOffsetId;
        public Vector3[] Offsets;
    }
}