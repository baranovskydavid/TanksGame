using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class UpdateTankMotorDataCommand : ICommand
    {
        private readonly PlayerTankModel _model;
        private readonly WheelView[] _leftWheelsViews;
        private readonly WheelView[] _rightWheelsViews;
        private readonly Rigidbody _rigidbody;

        public UpdateTankMotorDataCommand(PlayerTankModel model)
        {
            _model = model;
            _leftWheelsViews = model.TankView.LeftWheelsViews;
            _rightWheelsViews = model.TankView.RightWheelsViews;
            _rigidbody = model.TankView.Rigidbody;
        }

        public void Execute()
        {
            ApplyChanges(_leftWheelsViews, _model.LeftWheelsCollidersData);
            ApplyChanges(_rightWheelsViews, _model.RightWheelsCollidersData);
            
            _rigidbody.MoveRotation(_rigidbody.rotation * _model.Rotation);
        }

        private void ApplyChanges(WheelView[] wheelViews, WheelsCollidersData wheelsCollidersData)
        {
            foreach (var wheelView in wheelViews)
            {
                wheelView.WheelCollider.motorTorque = wheelsCollidersData.MotorTorque;
                wheelView.WheelCollider.brakeTorque = wheelsCollidersData.BrakeTorque;
            }
        }
    }

    public class UpdateTankMotorDataCommandSignal : ISignal
    {
    }
}