using Scenes.Scene_0_Main.Scripts.Views;
using Scenes.Scene_1_Authorization.Scripts.Signals;

namespace Scenes.Scene_1_Authorization.Scripts.Views
{
    public class AdditionalInfoButtonView : ViewBase
    {
        public string Description;

        public void OnSelect() 
        {
            Signal.Fire(new AdditionalInfoButtonSelectedViewSignal(this));
        }
        
        public void OnDeselect() 
        {
            Signal.Fire<AdditionalInfoButtonDeselectedViewSignal>();
        }
    }
}