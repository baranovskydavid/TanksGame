using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using TMPro;
using UnityEngine.UI;

namespace Scenes.Scene_3_Battlefield.Scripts.Views
{
    public class PlayerGameplayView : ViewBase
    {
        public TextMeshProUGUI Text_Speedometer;
        public TextMeshProUGUI Text_Distancemeter;
        public Image Image_Point;
    
        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
        }
    }
}