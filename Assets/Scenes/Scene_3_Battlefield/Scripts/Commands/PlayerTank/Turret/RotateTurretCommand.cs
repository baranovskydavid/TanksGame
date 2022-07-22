using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Turret
{
    public class RotateTurretCommand : ICommand
    {
        private readonly PlayerTankModel _model;
        private readonly Common.Scripts.Installers.Turret _settings;
        private readonly Transform _turret;

        public RotateTurretCommand(PlayerTankModel model)
        {
            _model = model;
            _settings = model.Settings.Turret;
            _turret = model.TankView.Turret;
        }

        public void Execute()
        {
            var direction = _model.CameraHitPointPosition - _turret.position;
            _turret.rotation = Quaternion.RotateTowards(_turret.rotation, Quaternion.LookRotation(direction), _settings.RotationSpeed * Time.fixedDeltaTime);
            _turret.localRotation = Quaternion.Euler(0, _turret.localRotation.eulerAngles.y, 0);
        }
    }

    public class RotateTurretCommandSignal : ISignal
    {
    }
}