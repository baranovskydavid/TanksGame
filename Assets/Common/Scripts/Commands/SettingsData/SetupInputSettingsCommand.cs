using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using UnityEngine;
using InputSettings = Common.Scripts.Json.SettingsData.InputSettings;

namespace Common.Scripts.Commands.SettingsData
{
    public class SetupInputSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private InputSettings _settings;

        public SetupInputSettingsCommand(SettingsModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            _settings = _model.SettingsData.inputSettings;

            CalculateMouseSensitivity();
        }

        private void CalculateMouseSensitivity()
        {
            var coefficient = MainConstants.Settings.DefaultResolutionWidth / Screen.currentResolution.width;
            _model.MouseSensitivity = _settings.MouseSensitivity * coefficient;
            _model.MouseVerticalInversion = _settings.MouseVerticalInversion ? -1 : 1;
            _model.BackwardMoveInversion = _settings.BackwardMoveInversion ? -1 : 1;

            _model.InputManager.LoadInputData();
        }
    }

    public class SetupInputSettingsCommandSignal : ISignal
    {
    }
}