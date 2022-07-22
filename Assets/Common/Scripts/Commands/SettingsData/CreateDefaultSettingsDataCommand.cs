using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using GraphicSettings = Common.Scripts.Json.SettingsData.GraphicSettings;
using SoundsSettings = Common.Scripts.Json.SettingsData.SoundsSettings;
using InputSettings = Common.Scripts.Json.SettingsData.InputSettings;

namespace Common.Scripts.Commands.SettingsData
{
    public class CreateDefaultSettingsDataCommand : ICommand
    {
        private readonly SettingsModel _model;

        public CreateDefaultSettingsDataCommand(SettingsModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            _model.SettingsData = new Json.SettingsData {graphicSettings = new GraphicSettings(), inputSettings = Input(), soundsSettings = new SoundsSettings()};
        }

        private InputSettings Input()
        {
            var settings = new InputSettings();
            _model.InputManager.CreateDefaultInputDataSaves();
            _model.InputManager.LoadInputData(); 
            return settings;
        }
    }

    public class CreateDefaultSettingsDataCommandSignal : ISignal
    {
    }
}