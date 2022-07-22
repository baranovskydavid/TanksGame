using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ShowReplaceKeyWarningCommand : ICommandWithParameters
    {
        private readonly SettingsModel _model;
        private readonly SettingsPanelMediator _mediator;
        
        public ShowReplaceKeyWarningCommand(SettingsModel model, SettingsPanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (ShowReplaceKeyWarningCommandSignal) signal;
            var view =  _mediator.View.InputSettingsView;
            
            view.Blocker.SetActive(true);
            view.ReplaceKeyWarningView.gameObject.SetActive(true);
            
            view.ReplaceKeyWarningView.SetupView(parameter.AxisName, parameter.IsPositiveKey, parameter.MatchedAxisName, parameter.MatchedKeyIsPositive);
            view.ReplaceKeyWarningView.Text_KeyName.text = _model.InputManager.GetAxisKeyCode(parameter.MatchedAxisName, parameter.MatchedKeyIsPositive).ToString();
        }
    }

    public class ShowReplaceKeyWarningCommandSignal : ISignal
    {
        public readonly string AxisName;
        public readonly bool IsPositiveKey;
        public readonly string MatchedAxisName;
        public readonly bool MatchedKeyIsPositive;

        public ShowReplaceKeyWarningCommandSignal(string axisName, bool isPositiveKey, string matchedAxisName, bool matchedKeyIsPositive)
        {
            AxisName = axisName;
            IsPositiveKey = isPositiveKey;
            MatchedAxisName = matchedAxisName;
            MatchedKeyIsPositive = matchedKeyIsPositive;
        }
    }
}