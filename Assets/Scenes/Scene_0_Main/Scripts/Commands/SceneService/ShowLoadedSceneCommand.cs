using Common.Scripts.Commands;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Signals;
using Zenject;

namespace Scenes.Scene_0_Main.Scripts.Commands.SceneService
{
    public class ShowLoadedSceneCommand : ICommandWithParameters
    {
        private readonly Services.SceneService _sceneService;
        private readonly SignalBus _signal;

        public ShowLoadedSceneCommand(Services.SceneService sceneService, SignalBus signal)
        {
            _sceneService = sceneService;
            _signal = signal;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (SceneLoadedCommandSignal) signal;
            
            _sceneService.SceneLoaded(parameter.SceneName);
            _signal.Fire(new ChangeCursorStateCommandSignal(!parameter.SceneName.Contains(MainConstants.ScenesNames.Battlefield)));
        }
    }
}