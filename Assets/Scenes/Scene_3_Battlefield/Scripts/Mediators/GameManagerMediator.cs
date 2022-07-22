using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_3_Battlefield.Scripts.Commands;
using Scenes.Scene_3_Battlefield.Scripts.Commands.Initialization;
using Scenes.Scene_3_Battlefield.Scripts.Views;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Mediators
{
    public class GameManagerMediator : MediatorBase
    {
        public GameManagerView View;

        public GameManagerMediator(SignalBus signal) : base(signal)
        {
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is GameManagerView view)
            {
                if (View == null)
                    View = view;

                Signal.Fire<InitializeGameCommandSignal>();
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is GameManagerView)
            {

            }
        }
    }
}