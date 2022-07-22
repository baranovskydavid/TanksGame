using Common.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class HideReplaceKeyWarningCommand : ICommand
    {
        private readonly SettingsPanelMediator _mediator;

        public HideReplaceKeyWarningCommand(SettingsPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View.InputSettingsView;
            view.ReplaceKeyWarningView.gameObject.SetActive(false);
            view.Blocker.SetActive(false);
        }
    }

    public class HideReplaceKeyWarningCommandSignal : ISignal
    {
    }
}