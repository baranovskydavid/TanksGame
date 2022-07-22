using Common.Scripts.Installers;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Factories;
using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class InstantiateSettingsPanelCommand : ICommand
    {
        private readonly UiPrefabs.Prefabs _settings;
        private readonly InstantiateGameObjectFactory _factory;
        private readonly GameModel _model;

        public InstantiateSettingsPanelCommand(UiPrefabs.Prefabs settings, InstantiateGameObjectFactory factory, GameModel model)
        {
            _settings = settings;
            _factory = factory;
            _model = model;
        }
        
        public void Execute()
        {
            _model.InstantiatedPanel = _factory.Create(_settings.SettingsPanel, _model.PanelsParent);
        }
    }

    public class InstantiateSettingsPanelCommandSignal : ISignal
    {
    }
}