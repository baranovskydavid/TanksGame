using Scenes.Scene_0_Main.Scripts.Installers;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Scenes.Scene_0_Main.Scripts.Commands.LoadingPanels
{
    public class SetLoadingPanelDataCommand : ICommandWithParameters
    {
        private readonly LoadingPanel.Settings _settings;
        private readonly MainModel _model;

        public SetLoadingPanelDataCommand(LoadingPanel.Settings settings, MainModel model)
        {
            _settings = settings;
            _model = model;
        }

        public void Execute(ISignal signal)
        {
            var view = _model.LoadingPanelView;
            view.Text_Description.text = _settings.Description;
            view.Image_Background.sprite = _settings.Background;
        }
    }
}