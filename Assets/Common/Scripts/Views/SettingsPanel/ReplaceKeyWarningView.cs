using Common.Scripts.Commands.SettingsPanel;
using Common.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts.Views.SettingsPanel
{
    public class ReplaceKeyWarningView : ViewBase
    {
        public TextMeshProUGUI Text_KeyName;
        [SerializeField]private Button _cancel;
        [SerializeField]private Button _replace;
        
        [HideInInspector] public string AxisName;
        [HideInInspector] public bool IsPositiveKey;
        [HideInInspector] public string MatchedAxisName;
        [HideInInspector] public bool MatchedKeyIsPositive;
        
        protected override void SubscribeOnListeners()
        {
            _cancel.onClick.AddListener(OnCancelClick);
            _replace.onClick.AddListener(OnReplaceClick);
        }

        private void OnDisable()
        {
            _cancel.onClick.RemoveListener(OnCancelClick);
            _replace.onClick.RemoveListener(OnReplaceClick);
        }

        private void OnCancelClick()
        {
            Signal.Fire<HideReplaceKeyWarningCommandSignal>();
        }

        private void OnReplaceClick()
        {
            Signal.Fire(new ReplaceInputKeyViewSignal(AxisName, IsPositiveKey, MatchedAxisName, MatchedKeyIsPositive));
        }

        public void SetupView(string axisName, bool isPositiveKey, string matchedAxisName, bool matchedKeyIsPositive)
        {
            AxisName = axisName;
            IsPositiveKey = isPositiveKey;
            MatchedAxisName = matchedAxisName;
            MatchedKeyIsPositive = matchedKeyIsPositive;
        }
    }
}