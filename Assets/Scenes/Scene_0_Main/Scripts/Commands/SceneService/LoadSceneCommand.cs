using Scenes.Scene_0_Main.Scripts.Commands.LoadingPanels;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Zenject;

namespace Scenes.Scene_0_Main.Scripts.Commands.SceneService
{
    public class LoadSceneCommand : ICommandWithParameters
    {
        private readonly Services.SceneService _sceneService;
        private readonly SignalBus _signal;

        public LoadSceneCommand(Services.SceneService sceneService, SignalBus signal)
        {
            _sceneService = sceneService;
            _signal = signal;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (LoadSceneCommandSignal) signal;

            _sceneService.LoadScene(parameter.SceneName);
            if (parameter.SceneName.Equals(MainConstants.ScenesNames.Authorization) || parameter.SceneName.Equals(MainConstants.ScenesNames.Hangar) || parameter.SceneName.Equals(MainConstants.ScenesNames.Battlefield)) {
                _signal.Fire<InstantiateLoadingPanelCommandSignal>();
            }
        }
    }
    
    public class LoadSceneCommandSignal : ISignal
    {
        public LoadSceneCommandSignal(string sceneName)
        {
            SceneName = sceneName;
        }
        public string SceneName { get; }
    }
}