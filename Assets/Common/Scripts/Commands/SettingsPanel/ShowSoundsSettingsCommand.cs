using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ShowSoundsSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private readonly SettingsPanelMediator _mediator;

        public ShowSoundsSettingsCommand(SettingsModel model, SettingsPanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }
        
        public void Execute()
        {
            var view = _mediator.View.SoundsSettingsView;
            var settings = _model.SettingsData.soundsSettings;

            view.Slider_SoundsVolume.value = settings.SoundsVolume;
            view.Slider_MusicVolume.value = settings.MusicVolume;
            view.Slider_PostEffectsVolume.value = settings.PostEffectsVolume;
        }
    }

    public class ShowSoundsSettingsCommandSignal : ISignal {}
}