using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Offline;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Views;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Mediators
{
    public class LogInOfflinePanelMediator : MediatorBase
    {
        public LogInOfflinePanelView View;

        public LogInOfflinePanelMediator(SignalBus signal) : base(signal) { }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is LogInOfflinePanelView view)
            {
                if (View == null)
                    View = view;
                
                Signal.Subscribe<LogInOfflineViewSignal>(LogIn);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is LogInOfflinePanelView)
            {
                Signal.Unsubscribe<LogInOfflineViewSignal>(LogIn);
            }
        }

        private void LogIn()
        {
            Signal.Fire<LogInOfflineCommandSignal>();
        }
    }
}