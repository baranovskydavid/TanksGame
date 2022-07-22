using System;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class UpdateStaticWheelsRotationCommand : ICommandWithParameters
    {
        public void Execute(ISignal signal)
        {
            var parameter = (UpdateStaticWheelsRotationCommandSignal) signal;

            foreach (var staticWheelView in parameter.StaticWheelViews) {
                SetRotation(parameter.AverageSpeed, staticWheelView);
            }
        }
        
        private static void SetRotation(float averageSpeed, StaticWheelView staticWheelView)
        {
            var distancePerFrame = averageSpeed * 1000f / 60f / 60f * Time.fixedDeltaTime;
            var wheelLength = (float) (staticWheelView.Radius * Math.PI);
            var angle = distancePerFrame / wheelLength * 360f;
            staticWheelView.transform.Rotate(staticWheelView.RotationAxis * angle);
        }
    }

    public class UpdateStaticWheelsRotationCommandSignal : ISignal
    {
        public readonly StaticWheelView[] StaticWheelViews;
        public readonly float AverageSpeed;

        public UpdateStaticWheelsRotationCommandSignal(StaticWheelView[] staticWheelViews, float averageSpeed)
        {
            StaticWheelViews = staticWheelViews;
            AverageSpeed = averageSpeed;
        }
    }
}