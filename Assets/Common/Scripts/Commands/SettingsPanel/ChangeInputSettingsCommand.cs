﻿using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ChangeInputSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private readonly SettingsPanelMediator _mediator;

        public ChangeInputSettingsCommand(SettingsModel model, SettingsPanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View.InputSettingsView;
            var settings = new Json.SettingsData.InputSettings
            {
                MouseSensitivity = view.Slider_MouseSensitivity.value,
                MouseVerticalInversion = view.Dropdown_MouseVerticalInversion.value == 0,
                BackwardMoveInversion = view.Dropdown_BackwardMoveInversion.value == 0,
            };

            _model.InputManager.SaveInputData();
            _model.SettingsData.inputSettings = settings;
        }
    }

    public class ChangeInputSettingsCommandSignal : ISignal
    {
    }
}