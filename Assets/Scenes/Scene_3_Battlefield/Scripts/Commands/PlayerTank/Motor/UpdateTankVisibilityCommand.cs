using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class UpdateTankVisibilityCommand : ICommandWithParameters
    {
        private readonly PlayerTankModel _model;
        private readonly SignalBus _signal;
        
        private readonly float _rotationAtPlaceSpeed;
        private readonly TankView _view;

        public UpdateTankVisibilityCommand(PlayerTankModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;

            _rotationAtPlaceSpeed = _model.Settings.Motor.RotationAtPlaceSpeed;
            _view = _model.TankView;
        }

        public void Execute(ISignal signal)
        {
            var horizontal =  ((UpdateTankVisibilityCommandSignal)signal).Horizontal;
            
            var averageSpeed = (int) _model.MotorInfo.AverageSpeed;
            var averageLeftSpeed = _model.MotorInfo.AverageLeftSpeed;
            var averageRightSpeed = _model.MotorInfo.AverageRightSpeed;

            if (averageSpeed.Equals(0) && !_model.Rotation.Equals(Quaternion.Euler(Vector3.zero))) {
                averageLeftSpeed = _rotationAtPlaceSpeed * horizontal;
                averageRightSpeed = -_rotationAtPlaceSpeed * horizontal;
            }
            
            _signal.Fire(new UpdateStaticWheelsRotationCommandSignal(_view.LeftStaticWheelsViews, averageLeftSpeed));
            _signal.Fire(new UpdateStaticWheelsRotationCommandSignal(_view.RightStaticWheelsViews, averageRightSpeed));
            
            _signal.Fire(new UpdateWheelsRotationAndPositionCommandSignal(_view.LeftWheelsViews, averageLeftSpeed));
            _signal.Fire(new UpdateWheelsRotationAndPositionCommandSignal(_view.RightWheelsViews, averageRightSpeed));
            
            _signal.Fire(new UpdateTrackTextureOffsetCommandSignal(_view.LeftTrackView, averageLeftSpeed));
            _signal.Fire(new UpdateTrackTextureOffsetCommandSignal(_view.RightTrackView, averageRightSpeed));
        }
    }

    public class UpdateTankVisibilityCommandSignal : ISignal
    {
        public readonly float Horizontal;

        public UpdateTankVisibilityCommandSignal(float horizontal)
        {
            Horizontal = horizontal;
        }
    }
}