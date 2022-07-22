using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Scenes.Scene_0_Main.Scripts.Commands.SceneService
{
    public class ReloadSceneCommand : ICommandWithParameters
    {
        private readonly Services.SceneService _sceneService;

        public ReloadSceneCommand(Services.SceneService sceneService)
        {
            _sceneService = sceneService;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (ReloadSceneCommandSignal) signal;
            _sceneService.ReloadScene(parameter.SceneName);
        }
    }

    public class ReloadSceneCommandSignal : ISignal
    {
        public ReloadSceneCommandSignal(string sceneName)
        {
            SceneName = sceneName;
        }

        public string SceneName { get; }
    }
}