using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Scenes.Scene_0_Main.Scripts.Signals
{
    public class OnApplicationLoadedCommandSignal : ISignal
    {
    }
    
    public class SceneLoadedCommandSignal : ISignal
    {
        public SceneLoadedCommandSignal(string sceneName)
        {
            SceneName = sceneName;
        }

        public string SceneName { get; }
    }
}