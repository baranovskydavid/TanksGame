using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scene_1_Authorization.Scripts.Views
{
    public class RestorePasswordPanelView : ViewBase
    {
        public TextMeshProUGUI Text_Title;
        public TextMeshProUGUI Text_Warning;
        
        [Header("Panels")] 
        public GameObject Panel_LogIn;

        [Header("Login")]
        public TextMeshProUGUI Title_Login;
        public TMP_InputField InputField_Login;
        public TextMeshProUGUI Placeholder_Login;
        public TextMeshProUGUI Text_LoginWarning;
        
        [Header("Password")]
        public TextMeshProUGUI Title_Password;
        public TMP_InputField InputField_Password;
        public TextMeshProUGUI Placeholder_Password;
        public TextMeshProUGUI Text_PasswordWarning;
        
        [Header("Actions")]
        public Button Button_SendRequest;
        public Button Button_Cancel;

        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            Button_SendRequest.onClick.AddListener(OnButtonSendRequestClick);
            Button_Cancel.onClick.AddListener(OnButtonCancelClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            Button_SendRequest.onClick.RemoveListener(OnButtonSendRequestClick);
            Button_Cancel.onClick.RemoveListener(OnButtonCancelClick);
        }

        private void OnButtonSendRequestClick()
        {
            Signal.Fire<SendRestorePasswordRequestViewSignal>();
        }
        
        private void OnButtonCancelClick()
        {
            Signal.Fire<CancelRestorePasswordViewSignal>();
        }
    }
}