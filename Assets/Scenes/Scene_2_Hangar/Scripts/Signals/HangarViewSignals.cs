using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_2_Hangar.Scripts.Views;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;

namespace Scenes.Scene_2_Hangar.Scripts.Signals
{
    #region Main Info View
    public class ShowPlayerNameViewSignal : ISignal { }
    
    public class ShowBanknotesCountViewSignal : ISignal { }
    
    public class ShowFreeExperienceCountViewSignal : ISignal { }
    #endregion
    
    #region Tanks List View
    public class SelectPreviewTankViewSignal : ISignal
    {
        public readonly TankPreviewView View;

        public SelectPreviewTankViewSignal(TankPreviewView view)
        {
            View = view;
        }
    }

    public class PreviewTankChangedViewSignal : ISignal
    {
        public readonly TankView View;

        public PreviewTankChangedViewSignal(TankView view)
        {
            View = view;
        }
    }

    #endregion
    
    #region Start Battle View
    public class StartBattleViewSignal : ISignal { }
    #endregion
}