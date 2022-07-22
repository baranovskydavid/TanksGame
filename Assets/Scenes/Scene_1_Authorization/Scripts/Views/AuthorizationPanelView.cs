using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine.UI;

namespace Scenes.Scene_1_Authorization.Scripts.Views
{
    public class AuthorizationPanelView : ViewBase
    {
        public Image Image_Background;
        public AdditionalInfoPanelView AdditionalInfoPanelView;

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
