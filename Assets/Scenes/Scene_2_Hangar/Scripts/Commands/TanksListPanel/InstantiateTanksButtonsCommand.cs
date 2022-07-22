using Common.Scripts.Installers;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_2_Hangar.Scripts.Factories;
using Scenes.Scene_2_Hangar.Scripts.Json;
using Scenes.Scene_2_Hangar.Scripts.Mediators;
using Scenes.Scene_2_Hangar.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.TanksListPanel
{
    public class InstantiateTanksButtonsCommand : ICommand
    {
        private readonly InstantiateGameObjectFactory _factory;
        private readonly TanksSettings.Settings _settings;
        private readonly TanksListPanelMediator _mediator;
        private readonly GameModel _model;
        private TanksListPanelView _view;

        public InstantiateTanksButtonsCommand(InstantiateGameObjectFactory factory, TanksSettings.Settings settings, TanksListPanelMediator mediator, GameModel model)
        {
            _factory = factory;
            _settings = settings;
            _mediator = mediator;
            _model = model;
        }

        public void Execute()
        {
            _view = _mediator.View;
            DestroySpawnedButtons();
            CheckTanksStatuses();
        }

        private void DestroySpawnedButtons()
        {
            for(var id = _view.SpawnedButtons.Count - 1; id >= 0; id--) {
                Object.Destroy(_view.SpawnedButtons[id].gameObject); }
        }
        
        private void CheckTanksStatuses()
        {
            var tanks = _model.PlayerData.Tanks;
            for (var id = 0; id <= tanks.Count - 1; id++) {
                if (tanks[id].tankStatus == Tank.TankStatus.Bought) {
                    _view.SpawnedButtons.Add(SetupButton(id));
                }
            }
        }

        private TankPreviewView SetupButton(int id)
        {
            var tankSettings = _settings.TanksList[id].MainInfo;
            var tankPreviewView = _factory.Create(_view.Prefab, _view.Parent).GetComponent<TankPreviewView>();

            tankPreviewView.Id = id;
            tankPreviewView.Image_Preview.sprite = tankSettings.Preview;
            tankPreviewView.Text_Name.text = tankSettings.Name;
            tankPreviewView.Text_Level.text = tankSettings.Level.ToString();
            
            return tankPreviewView;
        }
    }

    public class InstantiateTanksButtonsCommandSignal : ISignal
    {
    }
}