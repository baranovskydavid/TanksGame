using Scenes.Scene_0_Main.Scripts.Signals;

namespace Scenes.Scene_0_Main.Scripts.Views
{
    public class ContentView : ViewBase
    {
        protected override void InitUiComponentsOnStart()
        {
            Signal.Fire<OnApplicationLoadedCommandSignal>();
        }
    }
}
