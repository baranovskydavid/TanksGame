using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Factories;
using Scenes.Scene_3_Battlefield.Scripts.Installers;
using Scenes.Scene_3_Battlefield.Scripts.Mediators;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.Initialization
{
    public class InstantiatePlayerCameraCommand : ICommand
    {
        private readonly PlayerCameraSettings.Settings _settings;
        private readonly InstantiateGameObjectFactory _factory;
        private readonly PlayerTankModel _model;
        private readonly GameManagerView _view;

        public InstantiatePlayerCameraCommand(PlayerCameraSettings.Settings settings, InstantiateGameObjectFactory factory,PlayerTankModel model, GameManagerMediator mediator)
        {
            _settings = settings;
            _factory = factory;
            _model = model;
            _view = mediator.View;
        }

        public void Execute()
        {
            var playerCamera = _factory.Create(_settings.Prefab, _view.CameraParent).transform;
            
            playerCamera.position = _model.TankView.CameraTarget.position;
            var eulerAngles = _model.TankView.transform.eulerAngles;
            playerCamera.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, 0);
            
            _model.PlayerCameraView = playerCamera.GetComponent<PlayerCameraView>();
        }
    }

    public class InstantiatePlayerCameraCommandSignal : ISignal
    {
    }
}