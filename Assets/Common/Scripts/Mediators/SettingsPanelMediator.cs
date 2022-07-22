using Common.Scripts.Commands;
using Common.Scripts.Commands.SettingsData;
using Common.Scripts.Commands.SettingsPanel;
using Common.Scripts.Models;
using Common.Scripts.Signals;
using Common.Scripts.Views.SettingsPanel;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Scripts.Mediators
{
    public class SettingsPanelMediator : MediatorBase
    {
        public SettingsPanelView View;
        private readonly GameModel _model;

        public SettingsPanelMediator(SignalBus signal, GameModel model) : base(signal)
        {
            _model = model;
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is SettingsPanelView view)
            {
                if (View == null)
                    View = view;

                _model.IsPaused = true;
                
                Setup();
                
                Signal.Subscribe<ChangeSettingsPanelContentViewSignal>(ChangeSettingsPanelContent);
                
                Signal.Subscribe<ApplySettingsChangesViewSignal>(ApplySettingsChanges);
                Signal.Subscribe<ResetSettingsViewSignal>(ResetSettings);
                
                Signal.Subscribe<CloseSettingsPanelViewSignal>(CloseSettingsPanel);
                Signal.Subscribe<SetSliderValueToTextViewSignal>(SetSliderValueToText);
                Signal.Subscribe<SignOutViewSignal>(SignOut);
                
                Signal.Subscribe<ChangeInputKeyViewSignal>(ChangeInputKey);
                Signal.Subscribe<ReplaceInputKeyViewSignal>(ReplaceInputKey);
                Signal.Subscribe<HideReplaceKeyWarningPanelViewSignal>(HideReplaceKeyWarning);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is SettingsPanelView)
            {
                _model.IsPaused = false;
                
                Signal.Unsubscribe<ChangeSettingsPanelContentViewSignal>(ChangeSettingsPanelContent);
                
                Signal.Unsubscribe<ApplySettingsChangesViewSignal>(ApplySettingsChanges);
                Signal.Unsubscribe<ResetSettingsViewSignal>(ResetSettings);
                
                Signal.Unsubscribe<CloseSettingsPanelViewSignal>(CloseSettingsPanel);
                Signal.Unsubscribe<SetSliderValueToTextViewSignal>(SetSliderValueToText);
                Signal.Unsubscribe<SignOutViewSignal>(SignOut);
                
                Signal.Unsubscribe<ChangeInputKeyViewSignal>(ChangeInputKey);
                Signal.Unsubscribe<ReplaceInputKeyViewSignal>(ReplaceInputKey);
                Signal.Unsubscribe<HideReplaceKeyWarningPanelViewSignal>(HideReplaceKeyWarning);
            }
        }

        private void Setup()
        {
            Signal.Fire<ShowGeneralSettingsCommandSignal>();
            Signal.Fire<ShowGraphicSettingsCommandSignal>();
            Signal.Fire<ShowInputSettingsCommandSignal>();
            Signal.Fire<ShowSoundsSettingsCommandSignal>();
        }

        private void ChangeSettingsPanelContent(ISignal signal)
        {
            var parameter = (ChangeSettingsPanelContentViewSignal) signal;
            Signal.Fire(new ChangeSettingsPanelContentCommandSignal(parameter.Id));
        }
        
        private void ApplySettingsChanges()
        {
            Signal.Fire<ChangeGraphicSettingsCommandSignal>();
            Signal.Fire<SetupGraphicSettingsCommandSignal>();
            
            Signal.Fire<ChangeInputSettingsCommandSignal>();
            Signal.Fire<SetupInputSettingsCommandSignal>();
            
            Signal.Fire<ChangeSoundsSettingsCommandSignal>();

            Signal.Fire<SaveSettingsDataCommandSignal>();
        }

        private void ResetSettings()
        {
            Signal.Fire<CreateDefaultSettingsDataCommandSignal>();
            ApplySettingsChanges();
            Setup();
        }

        private void CloseSettingsPanel()
        {
            Signal.Fire<DestroyInstantiatedPanelCommandSignal>();
            Signal.Fire<SetupInputSettingsCommandSignal>();
            if (SceneManager.GetSceneByName(MainConstants.ScenesNames.Battlefield).isLoaded) {
                Signal.Fire(new ChangeCursorStateCommandSignal(false));
            }
        }

        private void SetSliderValueToText(ISignal signal)
        {
            var parameter = (SetSliderValueToTextViewSignal) signal;
            parameter.Text.text = parameter.Value.ToString();
        }

        private void SignOut()
        {
            Signal.Fire<SignOutCommandSignal>();
        }

        private void ChangeInputKey(ISignal signal)
        {
            var parameter = (ChangeInputKeyViewSignal) signal;
            Signal.Fire(new ChangeInputKeyCommandSignal(parameter.View));
            Signal.Fire(new ChangeListenForKeyTextStateCommandSignal(true));
        }

        private void ReplaceInputKey(ISignal signal)
        {
            var parameter = (ReplaceInputKeyViewSignal) signal;
            Signal.Fire(new ReplaceInputKeyCommandSignal(parameter.AxisName, parameter.IsPositiveKey, parameter.MatchedAxisName, parameter.MatchedKeyIsPositive));
        }

        private void HideReplaceKeyWarning()
        {
            Signal.Fire<HideReplaceKeyWarningCommandSignal>();
        }
    }
}