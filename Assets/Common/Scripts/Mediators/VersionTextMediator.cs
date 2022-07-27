using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Common.Scripts.Mediators
{
    public class VersionTextMediator : MediatorBase
    {
        private VersionTextView _view;
        
        public VersionTextMediator(SignalBus signal) : base(signal) { }

        protected override void InitView(OnViewEnableViewSignal signal)
        {
            if (signal.View is VersionTextView view)
            {
                if (_view == null)
                {
                    _view = view;
                    
                    Signal.Subscribe<SetVersionTextViewSignal>(SetVersionText);
                }
            }
        }

        protected override void DisposeView(OnViewDisableViewSignal signal)
        {
            if (signal.View is VersionTextView)
            {
                if (_view != null)
                {
                    _view = null;
                    
                    Signal.Unsubscribe<SetVersionTextViewSignal>(SetVersionText);
                }
            }
        }
        
        private void SetVersionText(ISignal signal)
        {
            var parameter = (SetVersionTextViewSignal) signal;
            parameter.Text.text = Application.version;
        }
    }
}
