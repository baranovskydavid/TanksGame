using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ChangeGraphicSettingsCommand: ICommand
    {
        private readonly SettingsModel _model;
        private readonly SettingsPanelMediator _mediator;

        public ChangeGraphicSettingsCommand(SettingsModel model, SettingsPanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View.GraphicSettingsView;
            var settings = new Json.SettingsData.GraphicSettings
            {
                GraphicQualityLevel = view.Dropdown_GraphicQuality.value,
                FrameRate = view.Dropdown_FrameRate.value,
                ResolutionValue = view.Dropdown_ScreenResolution.value,
                FullScreenMode = view.Dropdown_FullscreenMode.value
            };
            
            _model.SettingsData.graphicSettings = settings;
        }
    }

    public class ChangeGraphicSettingsCommandSignal: ISignal { }
}