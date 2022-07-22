using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Views.Tank
{
    public class WheelView : ViewBase
    {
        public Transform Bone;
        public WheelCollider WheelCollider;

        [Header("Settings")] 
        public Vector3 RotationAxis;
        public float Radius;

        [HideInInspector] public Vector3 BoneDefaultLocalPosition;
    }
}