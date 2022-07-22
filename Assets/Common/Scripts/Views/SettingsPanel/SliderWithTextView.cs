using Common.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts.Views.SettingsPanel
{
    public class SliderWithTextView : ViewBase
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;

        protected override void InitUiComponentsOnStart()
        {
            OnSliderValueChanged(_slider.value);
        }

        protected override void SubscribeOnListeners()
        {
           _slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        protected override void UnsubscribeFromListeners()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            Signal.Fire(new SetSliderValueToTextViewSignal(value, _text));
        }
    }
}