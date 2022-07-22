using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ShowGeneralSettingsCommand : ICommand
    {
        private readonly SettingsModel _model;
        private readonly GameModel _gameModel;
        private readonly SettingsPanelMediator _mediator;
        
        public ShowGeneralSettingsCommand(SettingsModel model, GameModel gameModel, SettingsPanelMediator mediator)
        {
            _model = model;
            _gameModel = gameModel;
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View.GeneralSettingsView;
            view.Text_UserName.text = _gameModel.PlayerData.PlayerName;
            view.Text_AccountBirthday.text = _gameModel.PlayerData.AccountBirthday;

            view.Text_NetworkMode.text = _gameModel.NetworkGameMode == NetworkGameMode.Online ? "Онлайн" : "Оффлайн";
        }
    }

    public class ShowGeneralSettingsCommandSignal : ISignal
    {
    }
}