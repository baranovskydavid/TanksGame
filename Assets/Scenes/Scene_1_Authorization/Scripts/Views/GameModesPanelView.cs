using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scene_1_Authorization.Scripts.Views
{
    public class GameModesPanelView : ViewBase
    {
        [Header("Game Modes")]
        public Button Button_Online;
        public Button Button_Offline;

        [Header("Panels")]
        public GameObject Panel_Online;
        public GameObject Panel_Offline;
        
        [Header("Colors for buttons")]
        public Color Color_SelectedButton;
        public Color Color_DeselectedButton;

        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            
            Button_Online.onClick.AddListener(OnPlayOnlineClick);
            Button_Offline.onClick.AddListener(OnPlayOfflineClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            
            Button_Online.onClick.RemoveListener(OnPlayOnlineClick);
            Button_Offline.onClick.RemoveListener(OnPlayOfflineClick);
        }

        private void OnPlayOnlineClick()
        {
            Signal.Fire(new ChangeGameModeViewSignal());
        }
        
        private void OnPlayOfflineClick()
        {
            Signal.Fire(new ChangeGameModeViewSignal(false));
        }
    }
}
