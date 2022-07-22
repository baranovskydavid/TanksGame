using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Common.Scripts.Views.SettingsPanel;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Zenject;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ChangeInputKeyCommand : ICommandWithParameters
    {
        private readonly SettingsPanelMediator _mediator;
        private readonly SettingsModel _model;
        private readonly SignalBus _signal;
        private InputKeyView _view;

        public ChangeInputKeyCommand(SettingsPanelMediator mediator, SettingsModel model, SignalBus signal)
        {
            _mediator = mediator;
            _model = model;
            _signal = signal;
        }

        public void Execute(ISignal signal)
        {
            _view = ((ChangeInputKeyCommandSignal) signal).View;
            _model.InputManager.RebindKey(OnComplete, OnMatch, OnCancelled, _view.AxisName, _view.IsPositive);
        }

        private void OnComplete()
        {
            _signal.Fire<ShowInputSettingsCommandSignal>();
            _signal.Fire(new ChangeListenForKeyTextStateCommandSignal(false));
        }
        
        private void OnMatch(string matchedAxisName, bool matchedKeyIsPositive)
        {
            _signal.Fire(new ChangeListenForKeyTextStateCommandSignal(false));
            _signal.Fire(new ShowReplaceKeyWarningCommandSignal(_view.AxisName, _view.IsPositive, matchedAxisName, matchedKeyIsPositive));
        }

        private void OnCancelled()
        {
            _signal.Fire(new ChangeListenForKeyTextStateCommandSignal(false));
        }
    }

    public class ChangeInputKeyCommandSignal : ISignal
    {
        public readonly InputKeyView View;

        public ChangeInputKeyCommandSignal(InputKeyView view)
        {
            View = view;
        }
    }
}