using Common.Scripts.Commands;
using Common.Scripts.Commands.PausePanel;
using Common.Scripts.Commands.SettingsPanel;
using Common.Scripts.Models;
using Common.Scripts.Signals;
using Common.Scripts.Views;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Scripts.Mediators
{
    public class PausePanelMediator : MediatorBase
    {
        public PausePanelView View;
        private readonly GameModel _model;

        public PausePanelMediator(SignalBus signal, GameModel model) : base(signal)
        {
            _model = model;
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is PausePanelView view)
            {
                if (View == null)
                    View = view;

                _model.IsPaused = true;
                Signal.Fire<SetupPausePanelCommandSignal>();
                
                Signal.Subscribe<ResumeGameViewSignal>(ResumeGame);
                Signal.Subscribe<OpenSettingsPanelViewSignal>(OpenSettings);
                Signal.Subscribe<ExitToHangarViewSignal>(ExitToHangar);
                Signal.Subscribe<ExitFromGameViewSignal>(ExitFromGame);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is PausePanelView)
            {
                _model.IsPaused = false;
                Signal.Unsubscribe<ResumeGameViewSignal>(ResumeGame);
                Signal.Unsubscribe<OpenSettingsPanelViewSignal>(OpenSettings);
                Signal.Unsubscribe<ExitToHangarViewSignal>(ExitToHangar);
                Signal.Unsubscribe<ExitFromGameViewSignal>(ExitFromGame);
            }
        }

        private void ResumeGame()
        {
            Signal.Fire<DestroyInstantiatedPanelCommandSignal>();
            if (SceneManager.GetSceneByName(MainConstants.ScenesNames.Battlefield).isLoaded) {
                Signal.Fire(new ChangeCursorStateCommandSignal(false));
            }
        }

        private void OpenSettings()
        {
            Signal.Fire<DestroyInstantiatedPanelCommandSignal>();
            Signal.Fire<InstantiateSettingsPanelCommandSignal>();
        }

        private void ExitToHangar()
        {
            Signal.Fire<DestroyInstantiatedPanelCommandSignal>();
            Signal.Fire<ExitToHangarCommandSignal>();
        }

        private void ExitFromGame()
        {
            Signal.Fire<DestroyInstantiatedPanelCommandSignal>();
            Signal.Fire<ExitFromGameCommandSignal>();
        }
    }
}