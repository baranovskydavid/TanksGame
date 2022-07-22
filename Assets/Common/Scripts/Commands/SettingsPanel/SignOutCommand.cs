using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Commands.SceneService;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Zenject;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class SignOutCommand : ICommand
    {
        private readonly GameModel _model;
        private readonly SignalBus _signal;


        public SignOutCommand(GameModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
        }

        public void Execute()
        {
            _model.PlayerData = null;
            _model.SelectedTankId = 0;
            
            _signal.Fire(new LoadSceneCommandSignal(MainConstants.ScenesNames.Authorization));
        }
    }

    public class SignOutCommandSignal : ISignal
    {
    }
}