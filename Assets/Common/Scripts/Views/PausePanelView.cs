using Common.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts.Views
{
    public class PausePanelView : ViewBase
    {
        [SerializeField] private Button _resume;
        [SerializeField] private Button _settings;
        public Button ExitToHangar;
        [SerializeField] private Button _exitFromGame;
        
        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            
            _resume.onClick.AddListener(OnResumeClick);
            _settings.onClick.AddListener(OnSettingsClick);
            ExitToHangar.onClick.AddListener(OnExitToHangarClick);
            _exitFromGame.onClick.AddListener(OnExitFromGameClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            
            _resume.onClick.RemoveListener(OnResumeClick);
            _settings.onClick.RemoveListener(OnSettingsClick);
            ExitToHangar.onClick.RemoveListener(OnExitToHangarClick);
            _exitFromGame.onClick.RemoveListener(OnExitFromGameClick);
        }

        private void OnResumeClick()
        {
            Signal.Fire<ResumeGameViewSignal>();
        }

        private void OnSettingsClick()
        {
            Signal.Fire<OpenSettingsPanelViewSignal>();
        }

        private void OnExitToHangarClick()
        {
            Signal.Fire<ExitToHangarViewSignal>();
        }

        private void OnExitFromGameClick()
        {
            Signal.Fire<ExitFromGameViewSignal>();
        }
    }
}