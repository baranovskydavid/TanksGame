using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_2_Hangar.Scripts.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scene_2_Hangar.Scripts.Views
{
    public class TankPreviewView : ViewBase
    {
        [HideInInspector] public int Id;
        [HideInInspector]public bool TankInMatch;
        
        public Image Image_Preview;
        public Button Button_Select;
        public TextMeshProUGUI Text_Name;
        public TextMeshProUGUI Text_Level;
        public TextMeshProUGUI Text_TankInMatch;

        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            Button_Select.onClick.AddListener(OnButtonSelectClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            Button_Select.onClick.RemoveListener(OnButtonSelectClick);
        }

        private void OnButtonSelectClick()
        {
            Signal.Fire(new SelectPreviewTankViewSignal(this));
        }
    }
}