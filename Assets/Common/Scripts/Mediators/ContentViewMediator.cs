using Common.Scripts.Commands;
using Common.Scripts.Models;
using Common.Scripts.Views;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Zenject;

namespace Common.Scripts.Mediators
{
    public class ContentViewMediator : MediatorBase
    {
        private ContentView _view;
        private readonly GameModel _model;

        public ContentViewMediator(SignalBus signal, GameModel model) : base(signal)
        {
            _model = model;
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is ContentView view)
            {
                if (_view == null)
                {
                    _view = view;
                    _model.PanelsParent = _view.PanelsParent;

                    Signal.Subscribe<StartLoadingSceneViewSignal>(StartLoadingScene);
                    Signal.Subscribe<SceneLoadingCompletedViewSignal>(SceneLoadingCompleted);
                }
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is ContentView view)
            {
                if (_view != null && _view.GetInstanceID() == view.GetInstanceID())
                {
                    Signal.Unsubscribe<StartLoadingSceneViewSignal>(StartLoadingScene);
                    Signal.Unsubscribe<SceneLoadingCompletedViewSignal>(SceneLoadingCompleted);
                }
            }
        }

        private void StartLoadingScene()
        {
            _view.Canvas.SetActive(false);
        }

        private void SceneLoadingCompleted()
        {
            _view.Canvas.SetActive(true);
        }
    }
}
