using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Turret
{
    public class GetHitPointCommand : ICommand
    {
        private readonly PlayerTankModel _model;
        private readonly Transform _trunk;
        private readonly Camera _camera;

        public GetHitPointCommand(PlayerTankModel model)
        {
            _model = model;
            _trunk = model.TankView.Trunk;
            _camera = model.PlayerCameraView.Camera;
        }

        public void Execute()
        {
            if (Physics.Raycast(_trunk.position, _trunk.forward, out var hit)) {
                _model.TrunkHitPointPosition = hit.point;
            }
            else {
                _model.TrunkHitPointPosition = _trunk.position + _trunk.forward * Vector3.Distance(_trunk.position, _model.CameraHitPointPosition);
            }
            _model.TrunkHitPointUiPosition = _camera.WorldToScreenPoint(_model.TrunkHitPointPosition);
        }
    }

    public class GetHitPointCommandSignal : ISignal { }
}