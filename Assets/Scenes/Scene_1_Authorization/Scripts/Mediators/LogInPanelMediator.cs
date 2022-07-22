using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Panel;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Views;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Mediators
{
    public class LogInPanelMediator : MediatorBase
    {
        public LogInPanelView View;

        public LogInPanelMediator(SignalBus signal) : base(signal)
        {
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is LogInPanelView view)
            {
                if (View == null)
                    View = view;

                Signal.Subscribe<LogInViewSignal>(LogIn);
                Signal.Subscribe<OpenRegistrationPanelViewSignal>(OpenRegistrationPanel);
                Signal.Subscribe<OpenRestorePasswordPanelViewSignal>(OpenRestorePasswordPanel);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is LogInPanelView)
            {
                Signal.Unsubscribe<LogInViewSignal>(LogIn);
                Signal.Unsubscribe<OpenRegistrationPanelViewSignal>(OpenRegistrationPanel);
                Signal.Unsubscribe<OpenRestorePasswordPanelViewSignal>(OpenRestorePasswordPanel);
            }
        }

        private void LogIn()
        {
            Signal.Fire<LogInCommandSignal>();
        }

        private void OpenRegistrationPanel()
        {
            Signal.Fire<OpenRegistrationPanelCommandSignal>();
        }

        private void OpenRestorePasswordPanel()
        {
            Signal.Fire<OpenRestorePasswordPanelCommandSignal>();
        }
    }
}
