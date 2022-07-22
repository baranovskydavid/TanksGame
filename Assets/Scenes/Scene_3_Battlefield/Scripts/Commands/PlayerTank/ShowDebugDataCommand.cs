using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Views;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank
{
    public class ShowDebugDataCommand : ICommand
    {
        private readonly PlayerTankModel _model;
        private readonly Transform _camera;
        private readonly TankView _tankView;

        public ShowDebugDataCommand(PlayerTankModel model)
        {
            _model = model;
            _camera = model.PlayerCameraView.Camera.transform;
            _tankView = model.TankView;
        }

        public void Execute()
        {
            if (!_tankView.IsDebugModeActive) return;
            
            Debug.DrawLine(_camera.position, _model.CameraHitPointPosition, Color.red);
            Debug.DrawLine(_tankView.Trunk.position, _model.TrunkHitPointPosition, Color.green);
        }
    }

    public class ShowDebugDataCommandSignal : ISignal
    {
    }
}