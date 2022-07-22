using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scene_1_Authorization.Scripts.Views
{
    public class RegistrationPanelView : ViewBase
    {
        public TextMeshProUGUI Text_Title;
        public TextMeshProUGUI Text_Warning;
        
        [Header("Panels")] 
        public GameObject Panel_LogIn;

        [Header("Nickname")] 
        [HideInInspector] public bool IsNicknameCorrect;
        public TextMeshProUGUI Title_Nickname;
        public TMP_InputField InputField_Nickname;
        public TextMeshProUGUI Placeholder_Nickname;
        public TextMeshProUGUI Text_NicknameWarning;
        
        [Header("Email")] 
        [HideInInspector] public bool IsEmailCorrect;
        public TextMeshProUGUI Title_Email;
        public TMP_InputField InputField_Email;
        public TextMeshProUGUI Placeholder_Email;
        public TextMeshProUGUI Text_EmailWarning;
        
        [Header("Password")] 
        [HideInInspector] public bool IsPasswordCorrect;
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
            
            InputField_Nickname.onDeselect.AddListener(CheckNicknameText);
            InputField_Email.onDeselect.AddListener(CheckEmailText);
            InputField_Password.onDeselect.AddListener(CheckPasswordText);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            
            Button_SendRequest.onClick.RemoveListener(OnButtonSendRequestClick);
            Button_Cancel.onClick.RemoveListener(OnButtonCancelClick);
            
            InputField_Nickname.onDeselect.RemoveListener(CheckNicknameText);
            InputField_Email.onDeselect.RemoveListener(CheckEmailText);
            InputField_Password.onDeselect.RemoveListener(CheckPasswordText);
        }

        private void OnButtonSendRequestClick()
        {
            if(IsNicknameCorrect && IsEmailCorrect && IsPasswordCorrect) Signal.Fire<SendRegisterUserRequestViewSignal>();
        }
        
        private void OnButtonCancelClick()
        {
            Signal.Fire<CancelRegistrationViewSignal>();
        }
        
        private void CheckNicknameText(string text)
        {
            Signal.Fire(new CheckNicknameTextViewSignal(text));
        }
        
        private void CheckEmailText(string text)
        {
            Signal.Fire(new CheckEmailTextViewSignal(text));
        }
        
        private void CheckPasswordText(string text)
        {
            Signal.Fire(new CheckPasswordTextViewSignal(text));
        }
    }
}