using Common.Scripts.Installers;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Factories;
using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Common.Scripts.Commands.PausePanel
{
    public class InstantiatePausePanelCommand : ICommand
    {
        private readonly InstantiateGameObjectFactory _factory;
        private readonly UiPrefabs.Prefabs _prefabs;
        private readonly GameModel _model;


        public InstantiatePausePanelCommand(InstantiateGameObjectFactory factory, UiPrefabs.Prefabs prefabs, GameModel model)
        {
            _factory = factory;
            _prefabs = prefabs;
            _model = model;
        }

        public void Execute()
        {
            _model.InstantiatedPanel = _factory.Create(_prefabs.PausePanel, _model.PanelsParent);
        }
    }

    public class InstantiatePausePanelCommandSignal : ISignal {}
}