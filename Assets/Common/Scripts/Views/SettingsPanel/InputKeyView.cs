using Common.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts.Views.SettingsPanel
{
    public class InputKeyView : ViewBase
    {
        [SerializeField] private Button _changeKey;
        public TextMeshProUGUI Key;
        
        [Header("Settings")]
        public string AxisName;
        public bool IsPositive;

        protected override void SubscribeOnListeners()
        {
            _changeKey.onClick.AddListener(ChangeKey);
        }

        protected override void UnsubscribeFromListeners()
        {
            _changeKey.onClick.RemoveListener(ChangeKey);
        }

        private void ChangeKey()
        {
            Signal.Fire(new ChangeInputKeyViewSignal(this));
        }
    }
}