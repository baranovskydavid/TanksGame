using Scenes.Scene_0_Main.Scripts.Signals;
using TMPro;
using UnityEngine.UI;

namespace Scenes.Scene_0_Main.Scripts.Views
{
    public class LoadingPanelView : ViewBase
    {
        public Image Image_Background;
        public TextMeshProUGUI Text_Description;

        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new StartLoadingSceneViewSignal());
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new SceneLoadingCompletedViewSignal());
        }
    }
}
