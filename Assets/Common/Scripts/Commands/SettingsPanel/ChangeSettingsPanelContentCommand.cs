using Common.Scripts.Installers;
using Common.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ChangeSettingsPanelContentCommand : ICommandWithParameters
    {
        private readonly SettingsPanelMediator _mediator;
        private readonly SettingsPanelSettings.Settings _settings;

        public ChangeSettingsPanelContentCommand(SettingsPanelMediator mediator, SettingsPanelSettings.Settings settings)
        {
            _mediator = mediator;
            _settings = settings;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (ChangeSettingsPanelContentCommandSignal) signal;
            var view = _mediator.View;

            foreach (var content in view.Contents) {
                content.SetActive(false);
            }

            foreach (var button in view.Buttons) {
                button.image.color = _settings.DeselectedButtonColor;
            }
            
            view.Contents[parameter.Id].SetActive(true);
            view.Buttons[parameter.Id].image.color = _settings.SelectedButtonColor;
            
            view.Button_ApplyChanges.gameObject.SetActive(parameter.Id != 0);
            view.Button_ResetSettings.gameObject.SetActive(parameter.Id != 0);
        }
    }

    public class ChangeSettingsPanelContentCommandSignal : ISignal
    {
        public readonly int Id;

        public ChangeSettingsPanelContentCommandSignal(int id)
        {
            Id = id;
        }
    }
}