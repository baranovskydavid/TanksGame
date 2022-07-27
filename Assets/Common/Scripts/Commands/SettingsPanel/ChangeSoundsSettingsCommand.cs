using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ChangeSoundsSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private readonly SettingsPanelMediator _mediator;

        public ChangeSoundsSettingsCommand(SettingsModel model, SettingsPanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View.SoundsSettingsView;
            var settings = new Json.SettingsData.SoundsSettings
            {
                SoundsVolume = view.Slider_SoundsVolume.value,
                MusicVolume = view.Slider_MusicVolume.value,
                PostEffectsVolume = view.Slider_PostEffectsVolume.value
            };

            _model.SettingsData.soundsSettings = settings;
        }
    }

    public class ChangeSoundsSettingsCommandSignal : ISignal {}
}