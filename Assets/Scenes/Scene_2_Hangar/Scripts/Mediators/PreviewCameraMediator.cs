using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Commands.PreviewCamera;
using Scenes.Scene_2_Hangar.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Views;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Mediators
{
    public class PreviewCameraMediator : MediatorBase
    {
        public PreviewCameraView View;

        public PreviewCameraMediator(SignalBus signal) : base(signal) { }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is PreviewCameraView view)
            {
                if (View == null)
                    View = view;
                
                Signal.Subscribe<PreviewTankChangedViewSignal>(OnTankChanged);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is PreviewCameraView)
            {
                Signal.Unsubscribe<PreviewTankChangedViewSignal>(OnTankChanged);
            }
        }

        private void OnTankChanged(ISignal signal)
        {
            var parameter = (PreviewTankChangedViewSignal) signal;
            Signal.Fire(new SetPreviewCameraPositionCommandSignal(parameter.View.CameraTarget.position));
        }
    }
}