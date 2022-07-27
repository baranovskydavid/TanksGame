using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Commands.TanksListPanel;
using Scenes.Scene_2_Hangar.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Views;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Mediators
{
    public class TanksListPanelMediator : MediatorBase
    {
        public TanksListPanelView View;

        public TanksListPanelMediator(SignalBus signal) : base(signal) { }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is TanksListPanelView view)
            {
                if (View == null)
                    View = view;

                Startup();
                Signal.Subscribe<SelectPreviewTankViewSignal>(SelectTank);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is TanksListPanelView)
            {
                Signal.Unsubscribe<SelectPreviewTankViewSignal>(SelectTank);
            }
        }

        private void Startup()
        {
            Signal.Fire<InstantiateTanksButtonsCommandSignal>();
            Signal.Fire(new SelectPreviewTankCommandSignal());
        }

        private void SelectTank(ISignal signal)
        {
            var parameter = (SelectPreviewTankViewSignal) signal;
            Signal.Fire(new SelectPreviewTankCommandSignal(parameter.View));
        }

        public void OnTankChanged(TankView tankView)
        {
            Signal.Fire(new PreviewTankChangedViewSignal(tankView));
        }
    }
}