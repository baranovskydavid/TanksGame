using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_2_Hangar.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scene_2_Hangar.Scripts.Views
{
    public class StartBattleView : ViewBase
    {
        [SerializeField] private Button _startMatch;
        
        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            _startMatch.onClick.AddListener(OnButtonStartMatchClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            _startMatch.onClick.RemoveListener(OnButtonStartMatchClick);
        }

        private void OnButtonStartMatchClick()
        {
            Signal.Fire<StartBattleViewSignal>();
        }
    }
}