using Scenes.Scene_0_Main.Scripts.Commands.SceneService;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Commands.StartBattlePanel;
using Scenes.Scene_2_Hangar.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Views;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Mediators
{
    public class StartBattlePanelMediator : MediatorBase
    {
        public StartBattleView View;

        public StartBattlePanelMediator(SignalBus signal) : base(signal)
        {
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is StartBattleView view)
            {
                if (View == null)
                    View = view;
                
                Signal.Subscribe<StartBattleViewSignal>(StartBattle);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is StartBattleView)
            {
                Signal.Unsubscribe<StartBattleViewSignal>(StartBattle);
            }
        }

        private void StartBattle()
        {
            Signal.Fire(new StartBattleCommandSignal());
        }
    }
}