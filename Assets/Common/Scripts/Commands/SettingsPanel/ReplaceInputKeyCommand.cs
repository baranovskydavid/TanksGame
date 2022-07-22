using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Zenject;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ReplaceInputKeyCommand : ICommandWithParameters
    {
        private readonly SettingsModel _model;
        private readonly SignalBus _signal;

        public ReplaceInputKeyCommand(SettingsModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (ReplaceInputKeyCommandSignal) signal;
            
            _model.InputManager.ReplaceAxesKeyCodes(OnComplete, parameter.AxisName, parameter.IsPositiveKey, parameter.MatchedAxisName, parameter.MatchedKeyIsPositive);
        }

        private void OnComplete()
        {
            _signal.Fire<ShowInputSettingsCommandSignal>();
            _signal.Fire<HideReplaceKeyWarningCommandSignal>();
        }
    }

    public class ReplaceInputKeyCommandSignal : ISignal
    {
        public readonly string AxisName;
        public readonly bool IsPositiveKey;
        public readonly string MatchedAxisName;
        public readonly bool MatchedKeyIsPositive;

        public ReplaceInputKeyCommandSignal(string axisName, bool isPositiveKey, string matchedAxisName, bool matchedKeyIsPositive)
        {
            AxisName = axisName;
            IsPositiveKey = isPositiveKey;
            MatchedAxisName = matchedAxisName;
            MatchedKeyIsPositive = matchedKeyIsPositive;
        }
    }
}