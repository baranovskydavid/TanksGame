using System.Collections.Generic;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_2_Hangar.Scripts.Views
{
    public class TanksListPanelView : ViewBase
    {
        public Transform Parent;
        public Transform TankParent;
        public GameObject Prefab;
        public GameObject TankHeader;
        [HideInInspector]public List<TankPreviewView> SpawnedButtons;
        
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