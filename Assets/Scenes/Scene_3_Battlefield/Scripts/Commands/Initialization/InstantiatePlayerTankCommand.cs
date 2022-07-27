using Common.Scripts.Installers;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Factories;
using Scenes.Scene_3_Battlefield.Scripts.Mediators;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Views;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.Initialization
{
    public class InstantiatePlayerTankCommand : ICommand
    {
        private readonly GameModel _gameModel;
        private readonly PlayerTankModel _model;
        private readonly TanksSettings.Settings _settings;
        private readonly InstantiateGameObjectFactory _factory;
        private readonly GameManagerView _view;

        public InstantiatePlayerTankCommand(GameModel gameModel, PlayerTankModel model, TanksSettings.Settings settings, InstantiateGameObjectFactory factory, GameManagerMediator mediator)
        {
            _gameModel = gameModel;
            _model = model;
            _settings = settings;
            _factory = factory;
            _view = mediator.View;
        }

        public void Execute()
        {
            _model.Settings = _settings.TanksList[_gameModel.SelectedTankId];

            var tank = _factory.Create( _model.Settings.MainInfo.PhysicTank, _view.TanksParent);
            var spawnPoint = _view.SpawnPoints[Random.Range(0, _view.SpawnPoints.Length)].transform;
            tank.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            
            var view = tank.GetComponent<TankView>();
            _model.TankView = view;
        }
    }

    public class InstantiatePlayerTankCommandSignal : ISignal { }
}