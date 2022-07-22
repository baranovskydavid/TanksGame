using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Commands.MainInfoPanel;
using Scenes.Scene_2_Hangar.Scripts.Signals;
using Scenes.Scene_2_Hangar.Scripts.Views;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Mediators
{
    public class MainInfoPanelMediator : MediatorBase
    {
        public UserHeaderPanelView PanelView;

        public MainInfoPanelMediator(SignalBus signal) : base(signal)
        {
        }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is UserHeaderPanelView view)
            {
                if (PanelView == null)
                    PanelView = view;
                
                Startup();
                Signal.Subscribe<ShowPlayerNameViewSignal>(ShowPlayerName);
                Signal.Subscribe<ShowBanknotesCountViewSignal>(ShowBanknotesCount);
                Signal.Subscribe<ShowFreeExperienceCountViewSignal>(ShowFreeExperienceCount);
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is UserHeaderPanelView)
            {
                Signal.Unsubscribe<ShowPlayerNameViewSignal>(ShowPlayerName);
                Signal.Unsubscribe<ShowBanknotesCountViewSignal>(ShowBanknotesCount);
                Signal.Unsubscribe<ShowFreeExperienceCountViewSignal>(ShowFreeExperienceCount);
            }
        }

        private void Startup()
        {
            ShowPlayerName();
            ShowBanknotesCount();
            ShowFreeExperienceCount();
        }

        private void ShowPlayerName()
        {
            Signal.Fire<ShowPlayerNameCommandSignal>();
        }
        
        private void ShowBanknotesCount()
        {
            Signal.Fire<ShowBanknotesCountCommandSignal>();
        }
        
        private void ShowFreeExperienceCount()
        {
            Signal.Fire<ShowFreeExperienceCountCommandSignal>();
        }
    }
}