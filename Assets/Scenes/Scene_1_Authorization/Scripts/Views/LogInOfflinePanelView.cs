using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scene_1_Authorization.Scripts.Views
{
    public class LogInOfflinePanelView : ViewBase
    {
        [SerializeField] private Button _logIn;
        
        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            _logIn.onClick.AddListener(OnButtonLogInClicked);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            _logIn.onClick.RemoveListener(OnButtonLogInClicked);
        }

        private void OnButtonLogInClicked()
        {
            Signal.Fire<LogInOfflineViewSignal>();
        }
    }
}