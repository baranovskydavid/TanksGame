using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_2_Hangar.Scripts.Mediators;


namespace Scenes.Scene_2_Hangar.Scripts.Commands.MainInfoPanel
{
    public class ShowFreeExperienceCountCommand : ICommand
    {
        private readonly MainInfoPanelMediator _panelMediator;
        private readonly GameModel _model;

        public ShowFreeExperienceCountCommand(MainInfoPanelMediator panelMediator, GameModel model)
        {
            _panelMediator = panelMediator;
            _model = model;
        }
        
        public void Execute()
        {
            _panelMediator.PanelView.Text_FreeExperienceCount.text = _model.PlayerData.FreeExperienceCount.ToString();
        }
    }

    public class ShowFreeExperienceCountCommandSignal : ISignal
    {
    }
}