using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Commands.SceneService;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.StartBattlePanel
{
    public class StartBattleCommand : ICommand
    {
        private readonly GameModel _model;
        private readonly SignalBus _signal;

        public StartBattleCommand(GameModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
        }

        public void Execute()
        {
            _model.InMatch = true;
            _signal.Fire(new LoadSceneCommandSignal("Battlefield"));
        }
    }

    public class StartBattleCommandSignal : ISignal
    {
    }
}