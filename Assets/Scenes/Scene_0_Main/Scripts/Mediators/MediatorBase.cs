using Scenes.Scene_0_Main.Scripts.Signals;
using Zenject;

namespace Scenes.Scene_0_Main.Scripts.Mediators
{
    public abstract class MediatorBase : IInitializable, ILateDisposable
    {
        protected readonly SignalBus Signal;

        protected MediatorBase(SignalBus signal)
        {
            Signal = signal;
        }

        public void Initialize()
        {
            Signal.Subscribe<OnViewEnableViewSignal>(InitView);
            Signal.Subscribe<OnViewDisableViewSignal>(DisposeView);

            InitWithoutView();
        }

        public void LateDispose()
        {
            Signal.Unsubscribe<OnViewEnableViewSignal>(InitView);
            Signal.Unsubscribe<OnViewDisableViewSignal>(DisposeView);

            DisposeWithoutView();
        }

        protected virtual void InitView(OnViewEnableViewSignal signal)
        {
        }

        protected virtual void DisposeView(OnViewDisableViewSignal signal)
        {
        }

        protected virtual void InitWithoutView()
        {
        }

        protected virtual void DisposeWithoutView()
        {
        }
    }
}