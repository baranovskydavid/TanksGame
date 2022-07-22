using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using UnityEngine;
using Zenject;
using GraphicSettings = Common.Scripts.Json.SettingsData.GraphicSettings;

namespace Common.Scripts.Commands.SettingsData
{
    public class SetupGraphicSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private readonly SignalBus _signal;
        private GraphicSettings _settings;

        public SetupGraphicSettingsCommand(SettingsModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
        }

        public void Execute()
        {
            _settings = _model.SettingsData.graphicSettings;
            
            QualitySettings.SetQualityLevel(_settings.GraphicQualityLevel);
            SetFrameRate();
            SetResolution();
        }

        private void SetFrameRate()
        {
            var frameRate = _settings.FrameRate switch {0 => 60, 1 => 75};
            var currentFrameRate = Application.targetFrameRate;
            if (!currentFrameRate.Equals(frameRate)) {
                Application.targetFrameRate = frameRate;
            }
        }
        
        private void SetResolution()
        {
            if (Screen.resolutions.Length - 1 < _settings.ResolutionValue)
            {
                _settings.ResolutionValue = Screen.resolutions.Length - 1;
                _signal.Fire<SaveSettingsDataCommandSignal>();
            }
            
            var resolution = Screen.resolutions[_settings.ResolutionValue];
            if (!Screen.currentResolution.Equals(resolution)) {
                Screen.SetResolution(resolution.width, resolution.height, (FullScreenMode) _settings.FullScreenMode);
            }
        }
    }

    public class SetupGraphicSettingsCommandSignal : ISignal
    {
    }
}