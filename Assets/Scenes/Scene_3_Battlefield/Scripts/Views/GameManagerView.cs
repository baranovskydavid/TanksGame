using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Views
{
    public class GameManagerView : ViewBase
    {
        public Transform[] SpawnPoints;
        public Transform TanksParent;
        public Transform CameraParent;
        
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