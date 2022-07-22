using System;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class UpdateTankMotorInfoCommand : ICommand
    {
        private readonly PlayerTankModel _model;
        private readonly MotorInfo _motorInfo;
        private readonly TankView _view;

        public UpdateTankMotorInfoCommand(PlayerTankModel model)
        {
            _model = model;
            _motorInfo = new MotorInfo();
            _view = model.TankView;
        }

        public void Execute()
        {
            CalculateInfo(_view.LeftWheelsViews, out _motorInfo.AverageLeftMotorTorque, out _motorInfo.AverageLeftBrakeTorque, out _motorInfo.AverageLeftRpm, out _motorInfo.AverageLeftSpeed);
            CalculateInfo(_view.RightWheelsViews, out _motorInfo.AverageRightMotorTorque, out _motorInfo.AverageRightBrakeTorque, out _motorInfo.AverageRightRpm, out _motorInfo.AverageRightSpeed);
            _motorInfo.AverageSpeed = (_motorInfo.AverageLeftSpeed + _motorInfo.AverageRightSpeed) / 2;
            
            _model.MotorInfo = _motorInfo;
        }

        private void CalculateInfo(WheelView[] wheelsViews, out float averageMotorTorque, out float averageBrakeTorque, out float averageRpm, out float averageSpeed)
        {
            averageMotorTorque = 0f; 
            averageBrakeTorque = 0f;
            averageRpm = 0f;
            averageSpeed = 0f;

            foreach (var wheelView in wheelsViews)
            {
                var collider = wheelView.WheelCollider;

                averageMotorTorque += collider.motorTorque;
                averageBrakeTorque += collider.brakeTorque;
                averageRpm += collider.rpm;
                averageSpeed += (float)(collider.radius * Math.PI * collider.rpm) * 60 / 1000;
            }
            
            averageMotorTorque /= wheelsViews.Length;
            averageBrakeTorque /= wheelsViews.Length;
            averageRpm /= wheelsViews.Length;
            averageSpeed /= wheelsViews.Length;
        }
    }

    public class UpdateTankMotorInfoCommandSignal : ISignal
    {
    }
}