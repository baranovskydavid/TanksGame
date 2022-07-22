using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Commands.Restore_Password_Panel;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Views;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Mediators
{
    public class RestorePasswordPanelMediator : MediatorBase
    {
        public RestorePasswordPanelView View;

        public RestorePasswordPanelMediator(SignalBus signal) : base(signal)
        {
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is RestorePasswordPanelView view)
            {
                if (View == null)
                    View = view;
                
                Signal.Subscribe<SendRestorePasswordRequestViewSignal>(SendRequest);
                Signal.Subscribe<CancelRestorePasswordViewSignal>(OnCancelClicked);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is RestorePasswordPanelView)
            {
                Signal.Unsubscribe<SendRestorePasswordRequestViewSignal>(SendRequest);
                Signal.Unsubscribe<CancelRestorePasswordViewSignal>(OnCancelClicked);
            }
        }

        private void SendRequest()
        {
            Signal.Fire<SendRestorePasswordRequestCommandSignal>();
        }

        private void OnCancelClicked()
        {
            Signal.Fire<CancelRestorePasswordCommandSignal>();
        }
    }
}