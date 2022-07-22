using Scenes.Scene_0_Main.Scripts.Signals;
using TMPro;
using UnityEngine;

namespace Scenes.Scene_0_Main.Scripts.Views
{
    public class VersionTextView : ViewBase
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            Signal.Fire(new SetVersionTextViewSignal(_text));
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
        }
    }
}
