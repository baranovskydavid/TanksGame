using Scenes.Scene_0_Main.Scripts.Interfaces;
using TMPro;

namespace Scenes.Scene_0_Main.Scripts.Signals
{
    public class OnViewEnableViewSignal : ISignal
    {
        public OnViewEnableViewSignal(IView view)
        {
            View = view;
        }

        public IView View { get; }
    }

    public class OnViewDisableViewSignal : ISignal
    {
        public OnViewDisableViewSignal(IView view)
        {
            View = view;
        }

        public IView View { get; }
    }
    
    #region Loading Panel
    public class StartLoadingSceneViewSignal : ISignal { }

    public class SceneLoadingCompletedViewSignal : ISignal { }
    
    public class SetVersionTextViewSignal : ISignal
    {
        public readonly TextMeshProUGUI Text;

        public SetVersionTextViewSignal(TextMeshProUGUI text)
        {
            Text = text;
        }
    }
    #endregion
}