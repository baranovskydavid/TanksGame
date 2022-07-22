using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_3_Battlefield.Scripts.Views;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Mediators
{
    public class PlayerGameplayMediator : MediatorBase
    {
        public PlayerGameplayView View;

        public PlayerGameplayMediator(SignalBus signal) : base(signal)
        {
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is PlayerGameplayView view)
            {
                if (View == null)
                    View = view;
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is PlayerGameplayView)
            {

            }
        }
    }
}