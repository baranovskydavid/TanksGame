using Common.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts.Views.SettingsPanel
{
    public class GeneralSettingsView : ViewBase
    {
        [Header("User Info")]
        public TextMeshProUGUI Text_UserName;
        public TextMeshProUGUI Text_AccountBirthday;
        [Header("Network Mode Info")] 
        public TextMeshProUGUI Text_NetworkMode;
        [SerializeField] private Button _signOut;

        protected override void SubscribeOnListeners()
        {
            _signOut.onClick.AddListener(OnSignOutClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            _signOut.onClick.RemoveListener(OnSignOutClick);
        }

        private void OnSignOutClick()
        {
            Signal.Fire<SignOutViewSignal>();
        }
    }
}