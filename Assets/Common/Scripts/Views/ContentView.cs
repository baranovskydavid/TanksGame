using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Common.Scripts.Views
{
    public class ContentView : ViewBase
    {
        public GameObject Canvas;
        public Transform PanelsParent;

        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
        }
    }
}
