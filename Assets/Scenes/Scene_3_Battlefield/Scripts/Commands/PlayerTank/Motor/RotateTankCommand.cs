using Common.Scripts.Installers;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class RotateTankCommand : ICommandWithParameters
    {
        private readonly PlayerTankModel _model;
        private readonly SettingsModel _settingsModel;
        private readonly TankSettings _settings;
        private float _rotationSpeed;
        
        public RotateTankCommand(PlayerTankModel model, SettingsModel settingsModel)
        {
            _model = model;
            _settingsModel = settingsModel;
            _settings = model.Settings;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (RotateTankCommandSignal) signal;
            
            if (parameter.Vertical >= 0) {
                _rotationSpeed = _settings.Motor.RotationSpeed;
            }
            else {
                _rotationSpeed = _settings.Motor.RotationSpeed * _settingsModel.BackwardMoveInversion;
            }

            _model.Rotation = Quaternion.Euler(Vector3.up * _rotationSpeed * parameter.Horizontal * Time.fixedDeltaTime);
        }
    }

    public class RotateTankCommandSignal : ISignal
    {
        public readonly float Horizontal;
        public readonly float Vertical;

        public RotateTankCommandSignal(float horizontal, float vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }
    }
}