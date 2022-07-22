using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Installers;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;


namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera
{
    public class GetHitPointCommand : ICommand
    {
        private readonly PlayerTankModel _model;
        private readonly PlayerCameraSettings.Settings _settings;
        private readonly Transform _camera;

        public GetHitPointCommand(PlayerTankModel model, PlayerCameraSettings.Settings settings)
        {
            _model = model;
            _settings = settings;
            _camera = model.PlayerCameraView.Camera.transform;
        }

        public void Execute()
        {
            if (Physics.Raycast(_camera.position, _camera.forward, out var hit)) {
                _model.CameraHitPointPosition = hit.point;
                _model.CameraHitPointDistance = (int)(hit.distance - Vector3.Distance(_camera.position, _model.TankView.CameraTarget.position));
            }
            else {
                _model.CameraHitPointPosition = _camera.position + _camera.forward * (_settings.DefaultDistanceToHitPoint + Vector3.Distance(_camera.position, _model.TankView.CameraTarget.position));
                _model.CameraHitPointDistance = 0;
            }
        }
    }

    public class GetHitPointCommandSignal : ISignal
    {
    }
}