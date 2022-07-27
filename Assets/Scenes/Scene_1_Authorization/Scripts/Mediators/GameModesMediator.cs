using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Commands;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using Scenes.Scene_1_Authorization.Scripts.Views;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Mediators
{
    public class GameModesMediator : MediatorBase
    {
        public GameModesPanelView View;
        
        public GameModesMediator(SignalBus signal) : base(signal) { }
        
        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is GameModesPanelView view)
            {
                if (View == null)
                    View = view;
                
                Signal.Subscribe<ChangeGameModeViewSignal>(ChangeGameMode);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is GameModesPanelView)
            {
                Signal.Unsubscribe<ChangeGameModeViewSignal>(ChangeGameMode);
            }
        }

        private void ChangeGameMode(ISignal signal)
        {
            var parameter = (ChangeGameModeViewSignal) signal;
            Signal.Fire(new ChangeGameModeCommandSignal(parameter.IsPlayOnline));
        }
    }
}
