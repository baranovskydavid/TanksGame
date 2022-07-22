using Common.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts.Views.SettingsPanel
{
    public class SettingsPanelView : ViewBase
    {
        [Header("Buttons")]
        public Button Button_ApplyChanges;
        public Button Button_ResetSettings;
        [SerializeField] private Button _close;
        
        [Header("Menu")]
        public GameObject[] Contents;
        public Button[] Buttons;

        [Header("Settings")] 
        public GeneralSettingsView GeneralSettingsView;
        public GraphicSettingsView GraphicSettingsView;
        public InputSettingsView InputSettingsView;
        public SoundsSettingsView SoundsSettingsView;
        
        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            Button_ApplyChanges.onClick.AddListener(OnApplyChangesClick);
            Button_ResetSettings.onClick.AddListener(OnResetSettingsClick);
            _close.onClick.AddListener(OnCloseClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            Button_ApplyChanges.onClick.RemoveListener(OnApplyChangesClick);
            Button_ResetSettings.onClick.RemoveListener(OnResetSettingsClick);
            _close.onClick.RemoveListener(OnCloseClick);
        }
        
        public void ChangeContent(int id)
        {
            Signal.Fire(new ChangeSettingsPanelContentViewSignal(id));
        }

        private void OnApplyChangesClick()
        {
            Signal.Fire<ApplySettingsChangesViewSignal>();
        } 
        
        private void OnResetSettingsClick()
        {
            Signal.Fire<ResetSettingsViewSignal>();
        }

        private void OnCloseClick()
        {
            Signal.Fire<CloseSettingsPanelViewSignal>();
        }
    }
}