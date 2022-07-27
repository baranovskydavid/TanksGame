using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Views.Tank
{
    public class TankView : ViewBase
    {
        public bool IsDebugModeActive;
        
        [Header("Camera")]
        public Transform CameraTarget;
        
        [Header("Physics")] 
        public Rigidbody Rigidbody;
        public Transform CenterOfMass;

        [Header("Tracks")] 
        public TrackView LeftTrackView;
        public TrackView RightTrackView;

        public StaticWheelView[] LeftStaticWheelsViews;
        public StaticWheelView[] RightStaticWheelsViews;
        
        public WheelView[] LeftWheelsViews;
        public WheelView[] RightWheelsViews;

        [Header("Turret")] 
        public Transform Turret;
        public Transform Trunk;
    }
}