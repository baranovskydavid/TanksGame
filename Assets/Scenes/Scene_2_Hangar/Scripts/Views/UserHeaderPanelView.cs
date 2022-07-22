using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using TMPro;
using UnityEngine.UI;

namespace Scenes.Scene_2_Hangar.Scripts.Views
{
    public class UserHeaderPanelView : ViewBase
    {
        public TextMeshProUGUI Text_PlayerName;
        public Button Button_OpenProfile;
        
        public TextMeshProUGUI Text_BanknotesCount;
        public Button Button_BuyBanknotes;

        public TextMeshProUGUI Text_FreeExperienceCount;
        public Button Button_BuyFreeExperience;

        protected override void SubscribeOnListeners()
        {
            Signal.Fire(new OnViewEnableViewSignal(this));
            
            Button_OpenProfile.onClick.AddListener(OnButtonOpenProfileClick);
            Button_BuyBanknotes.onClick.AddListener(OnButtonBuyBanknotesClick);
            Button_BuyFreeExperience.onClick.AddListener(OnButtonBuyFreeExperienceClick);
        }

        protected override void UnsubscribeFromListeners()
        {
            Signal.Fire(new OnViewDisableViewSignal(this));
            
            Button_OpenProfile.onClick.RemoveListener(OnButtonOpenProfileClick);
            Button_BuyBanknotes.onClick.RemoveListener(OnButtonBuyBanknotesClick);
            Button_BuyFreeExperience.onClick.RemoveListener(OnButtonBuyFreeExperienceClick);
        }

        private void OnButtonOpenProfileClick()
        {
        }
        
        private void OnButtonBuyBanknotesClick()
        {
        }
        
        private void OnButtonBuyFreeExperienceClick()
        {
        }
    }
}