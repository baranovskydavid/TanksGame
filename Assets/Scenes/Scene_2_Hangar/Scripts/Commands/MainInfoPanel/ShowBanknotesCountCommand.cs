using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_2_Hangar.Scripts.Mediators;


namespace Scenes.Scene_2_Hangar.Scripts.Commands.MainInfoPanel
{
    public class ShowBanknotesCountCommand : ICommand
    {
        private readonly MainInfoPanelMediator _panelMediator;
        private readonly GameModel _model;

        public ShowBanknotesCountCommand(MainInfoPanelMediator panelMediator, GameModel model)
        {
            _panelMediator = panelMediator;
            _model = model;
        }
        
        public void Execute()
        {
            _panelMediator.PanelView.Text_BanknotesCount.text = _model.PlayerData.BanknotesCount.ToString();
        }
    }

    public class ShowBanknotesCountCommandSignal : ISignal
    {
    }
}