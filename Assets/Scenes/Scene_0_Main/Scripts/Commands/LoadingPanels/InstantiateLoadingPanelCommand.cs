using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Factories;
using Scenes.Scene_0_Main.Scripts.Installers;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_0_Main.Scripts.Commands.LoadingPanels
{
    public class InstantiateLoadingPanelCommand : ICommand
    {
        private readonly InstantiateGameObjectFactory _factory;
        private readonly LoadingPanel.Settings _settings;
        private readonly MainModel _model;

        public InstantiateLoadingPanelCommand(InstantiateGameObjectFactory factory, LoadingPanel.Settings settings, MainModel model)
        {
            _factory = factory;
            _settings = settings;
            _model = model;

            _model.Canvas = GameObject.Find(MainConstants.Paths.PanelsParent).transform;
        }

        public void Execute()
        {
            _model.LoadingPanelView = _factory.Create(_settings.Prefab, _model.Canvas.transform).GetComponent<LoadingPanelView>();
        }
    }
    
    public class InstantiateLoadingPanelCommandSignal : ISignal { }
}
