using System;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class UpdateWheelsRotationAndPositionCommand : ICommandWithParameters
    {
        public void Execute(ISignal signal)
        {
            var parameter = (UpdateWheelsRotationAndPositionCommandSignal) signal;

            foreach (var wheelView in parameter.WheelViews) {
                SetRotation(parameter.AverageSpeed, wheelView);
                SetPositions(wheelView);
            }
        }

        private static void SetRotation(float averageSpeed, WheelView wheelView)
        {
            var distancePerFrame = averageSpeed * 1000f / 60f / 60f * Time.fixedDeltaTime;
            var wheelLength = (float) (wheelView.Radius * Math.PI);
            var angle = distancePerFrame / wheelLength * 360f;
            wheelView.transform.Rotate(wheelView.RotationAxis * angle);
        }

        private static void SetPositions(WheelView wheelView)
        {
            if (wheelView.BoneDefaultLocalPosition.Equals(Vector3.zero)) {
                wheelView.BoneDefaultLocalPosition = wheelView.Bone.localPosition;
            }

            wheelView.WheelCollider.GetWorldPose(out var position, out var rotation);
            wheelView.transform.position = position;
            wheelView.Bone.localPosition = new Vector3(wheelView.BoneDefaultLocalPosition.x, wheelView.transform.localPosition.y, wheelView.BoneDefaultLocalPosition.z);
        }
    }

    public class UpdateWheelsRotationAndPositionCommandSignal : ISignal
    {
        public readonly WheelView[] WheelViews;
        public readonly float AverageSpeed;

        public UpdateWheelsRotationAndPositionCommandSignal(WheelView[] wheelViews, float averageSpeed)
        {
            WheelViews = wheelViews;
            AverageSpeed = averageSpeed;
        }
    }
}