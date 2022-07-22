using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Commands.Registration_Panel;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Views;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Mediators
{
    public class RegistrationPanelMediator : MediatorBase
    {
        public RegistrationPanelView View;

        public RegistrationPanelMediator(SignalBus signal) : base(signal)
        {
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is RegistrationPanelView view)
            {
                if (View == null)
                    View = view;
                
                Signal.Subscribe<SendRegisterUserRequestViewSignal>(SendRequest);
                Signal.Subscribe<CancelRegistrationViewSignal>(OnCancelClicked);
                
                Signal.Subscribe<NicknameCheckingResultViewSignal>(NicknameCheckingResult);
                Signal.Subscribe<EmailCheckingResultViewSignal>(EmailCheckingResult);
                Signal.Subscribe<PasswordCheckingResultViewSignal>(PasswordCheckingResult);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is RegistrationPanelView)
            {
                Signal.Unsubscribe<SendRegisterUserRequestViewSignal>(SendRequest);
                Signal.Unsubscribe<CancelRegistrationViewSignal>(OnCancelClicked);
                
                Signal.Unsubscribe<NicknameCheckingResultViewSignal>(NicknameCheckingResult);
                Signal.Unsubscribe<EmailCheckingResultViewSignal>(EmailCheckingResult);
                Signal.Unsubscribe<PasswordCheckingResultViewSignal>(PasswordCheckingResult);
            }
        }

        private void SendRequest()
        {
            Signal.Fire<SendRegisterUserRequestCommandSignal>();
        }

        private void OnCancelClicked()
        {
            Signal.Fire<CancelRegistrationCommandSignal>();
        }
        
        private void NicknameCheckingResult(ISignal signal)
        {
            var parameter = (NicknameCheckingResultViewSignal) signal;

            View.IsNicknameCorrect = parameter.Warning.Length == 0;
            View.Text_NicknameWarning.text = parameter.Warning.Length == 0 ? "" : parameter.Warning;
        }
        
        private void EmailCheckingResult(ISignal signal)
        {
            var parameter = (EmailCheckingResultViewSignal) signal;
            
            View.IsEmailCorrect = parameter.Warning.Length == 0;
            View.Text_EmailWarning.text = parameter.Warning.Length == 0 ? "" : parameter.Warning;
        }
        
        private void PasswordCheckingResult(ISignal signal)
        {
            var parameter = (PasswordCheckingResultViewSignal) signal;
            
            View.IsPasswordCorrect = parameter.Warning.Length == 0;
            View.Text_PasswordWarning.text = parameter.Warning.Length == 0 ? "" : parameter.Warning;
        }
    }
}