using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Commands;
using Scenes.Scene_1_Authorization.Scripts.Commands.Additional_Info_Panel;
using Scenes.Scene_1_Authorization.Scripts.Commands.Check_Text_Correctness;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Views;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Mediators
{
    public class AuthorizationPanelMediator : MediatorBase
    {
        public AuthorizationPanelView View;

        public AuthorizationPanelMediator(SignalBus signal) : base(signal) { }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is AuthorizationPanelView view)
            {
                if (View == null)
                    View = view;
                
                SetPanelData();
                
                Signal.Subscribe<CheckEmailTextViewSignal>(CheckEmail);
                Signal.Subscribe<CheckPasswordTextViewSignal>(CheckPassword);
                Signal.Subscribe<CheckNicknameTextViewSignal>(CheckNickname);
                
                Signal.Subscribe<AdditionalInfoButtonSelectedViewSignal>(AdditionalInfoButtonSelected);
                Signal.Subscribe<AdditionalInfoButtonDeselectedViewSignal>(AdditionalInfoButtonDeselected);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is AuthorizationPanelView)
            {
                Signal.Unsubscribe<CheckEmailTextViewSignal>(CheckEmail);
                Signal.Unsubscribe<CheckPasswordTextViewSignal>(CheckPassword);
                Signal.Unsubscribe<CheckNicknameTextViewSignal>(CheckNickname);
                
                Signal.Unsubscribe<AdditionalInfoButtonSelectedViewSignal>(AdditionalInfoButtonSelected);
                Signal.Unsubscribe<AdditionalInfoButtonDeselectedViewSignal>(AdditionalInfoButtonDeselected);
            }
        }

        private void SetPanelData()
        {
            Signal.Fire<SetAuthorizationPanelDataCommandSignal>();
        }

        private void CheckEmail(ISignal signal)
        {
            var parameter = (CheckEmailTextViewSignal) signal;
            Signal.Fire(new CheckEmailTextCommandSignal(parameter.Text));
        }

        private void CheckPassword(ISignal signal)
        {
            var parameter = (CheckPasswordTextViewSignal) signal;
            Signal.Fire(new CheckPasswordTextCommandSignal(parameter.Text));
        }

        private void CheckNickname(ISignal signal)
        {
            var parameter = (CheckNicknameTextViewSignal) signal;
            Signal.Fire(new CheckNicknameTextCommandSignal(parameter.Text));
        }
        
        public void NicknameCheckingResult(string text = "")
        {
            Signal.Fire(new NicknameCheckingResultViewSignal(text));
        } 

        public void EmailCheckingResult(string text = "")
        {
            Signal.Fire(new EmailCheckingResultViewSignal(text));
        } 
        
        public void PasswordCheckingResult(string text = "")
        {
            Signal.Fire(new PasswordCheckingResultViewSignal(text));
        }

        private void AdditionalInfoButtonSelected(ISignal signal)
        {
            var parameter = (AdditionalInfoButtonSelectedViewSignal) signal;
            Signal.Fire(new ShowAdditionalInfoPanelCommandSignal(parameter.View));
        }
        
        private void AdditionalInfoButtonDeselected()
        {
            Signal.Fire<HideAdditionalInfoPanelCommandSignal>();
        }
    }
}
