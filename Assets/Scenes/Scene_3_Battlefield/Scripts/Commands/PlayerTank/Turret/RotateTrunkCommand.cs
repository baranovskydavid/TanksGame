using Common.Scripts.Installers;
using Plugins.Upgraded_Math;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Turret
{
    public class RotateTrunkCommand : ICommand
    {
        private readonly PlayerTankModel _model;
        private readonly Trunk _settings;
        private readonly Transform _trunk;

        public RotateTrunkCommand(PlayerTankModel model)
        {
            _model = model;
            _settings = model.Settings.Trunk;
            _trunk = model.TankView.Trunk;
        }

        public void Execute()
        {
            var direction = _model.CameraHitPointPosition - _trunk.position;

            _trunk.rotation = Quaternion.RotateTowards(_trunk.rotation, Quaternion.LookRotation(direction), _settings.RotationSpeed * Time.fixedDeltaTime);
            _trunk.localEulerAngles = new Vector3(UpgradedMath.ClampAngle(_trunk.localEulerAngles.x, _settings.MinAngle, _settings.MaxAngle), 0, 0);
        }
    }

    public class RotateTrunkCommandSignal : ISignal
    {
    }
}