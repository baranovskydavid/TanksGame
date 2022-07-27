using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Installers;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera
{
    public class MoveCameraToTargetCommand : ICommand
    {
        private readonly PlayerCameraSettings.Settings _settings;
        private readonly Transform _target;
        private readonly Transform _pivot;

        public MoveCameraToTargetCommand(PlayerCameraSettings.Settings settings, PlayerTankModel model)
        {
            _settings = settings;
            _target = model.TankView.CameraTarget;
            _pivot = model.PlayerCameraView.transform;
        }

        public void Execute()
        {
            _pivot.position = Vector3.Lerp(_pivot.position, _target.position, _settings.MovingSpeed * Time.fixedDeltaTime);
        }
    }

    public class MovelayerCameraToTargetCommandSignal : ISignal { }
}