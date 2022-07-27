using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ShowInputSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private readonly SettingsPanelMediator _mediator;

        public ShowInputSettingsCommand(SettingsModel model, SettingsPanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View.InputSettingsView;
            var settings = _model.SettingsData.inputSettings;

            view.Slider_MouseSensitivity.value = settings.MouseSensitivity;
            view.Dropdown_MouseVerticalInversion.value = settings.MouseVerticalInversion ? 0 : 1;
            view.Dropdown_BackwardMoveInversion.value = settings.BackwardMoveInversion ? 0 : 1;
            
            foreach (var keyView in view.InputKeysViews) {
                keyView.Key.text = _model.InputManager.GetAxisKeyCode(keyView.AxisName, keyView.IsPositive).ToString();
            }
        }
    }

    public class ShowInputSettingsCommandSignal : ISignal {}
}