using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Zenject;

namespace Scenes.Scene_0_Main.Scripts.Commands.SceneService
{
    public class LoadStartupSceneCommand : ICommand
    {
        private readonly SignalBus _signal;

        public LoadStartupSceneCommand(SignalBus signal)
        {
            _signal = signal;
        }

        public void Execute()
        {
            _signal.Fire(new LoadSceneCommandSignal(MainConstants.ScenesNames.Authorization));
        }
    }
}