using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Common.Scripts.Views.SettingsPanel;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using TMPro;
using UnityEngine;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ShowGraphicSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private readonly SettingsPanelMediator _mediator;

        public ShowGraphicSettingsCommand(SettingsModel model, SettingsPanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View.GraphicSettingsView;
            var settings = _model.SettingsData.graphicSettings;

            view.Dropdown_GraphicQuality.value = settings.GraphicQualityLevel;
            view.Dropdown_FrameRate.value = settings.FrameRate;
            ShowAvailableScreenResolutions(view, settings.ResolutionValue);
            view.Dropdown_FullscreenMode.value = settings.FullScreenMode;
        }

        private static void ShowAvailableScreenResolutions(GraphicSettingsView view, int value)
        {
            var options = new TMP_Dropdown.OptionDataList();
            foreach (var resolution in Screen.resolutions)
            {
                var option = new TMP_Dropdown.OptionData {text = resolution.ToString()};
                options.options.Add(option);
            }

            view.Dropdown_ScreenResolution.AddOptions(options.options);
            view.Dropdown_ScreenResolution.value = value;
        }
    }

    public class ShowGraphicSettingsCommandSignal : ISignal { }
}
