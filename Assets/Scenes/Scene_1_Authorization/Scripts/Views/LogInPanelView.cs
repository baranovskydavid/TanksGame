using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scene_1_Authorization.Scripts.Views
{
    public class LogInPanelView : ViewBase
    {
        public TextMeshProUGUI Text_Title;
        public TextMeshProUGUI Text_Warning;
        
        [Header("Panels")] 
        public GameObject Panel_Registration;
        public GameObject Panel_RestorePassword;
        
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
        public Button Button_LogIn;
        public Button Button_Registration;
        public Button Button_RestorePassword;
        
        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            
            Button_LogIn.onClick.AddListener(OnButtonLoginClick);
            Button_Registration.onClick.AddListener(OnButtonRegistrationClick);
            Button_RestorePassword.onClick.AddListener(OnButtonRestorePasswordClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            
            Button_LogIn.onClick.RemoveListener(OnButtonLoginClick);
            Button_Registration.onClick.RemoveListener(OnButtonRegistrationClick);
            Button_RestorePassword.onClick.RemoveListener(OnButtonRestorePasswordClick);
        }

        private void OnButtonLoginClick()
        {
            Signal.Fire(new LogInViewSignal());
        }

        private void OnButtonRegistrationClick()
        {
            Signal.Fire(new OpenRegistrationPanelViewSignal());
        }

        private void OnButtonRestorePasswordClick()
        {
            Signal.Fire(new OpenRestorePasswordPanelViewSignal());
        }


    }
}
