using Common.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Common.Scripts.Commands.SettingsPanel
{
    public class ChangeListenForKeyTextStateCommand : ICommandWithParameters
    {
        private readonly SettingsPanelMediator _mediator;

        public ChangeListenForKeyTextStateCommand(SettingsPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (ChangeListenForKeyTextStateCommandSignal) signal;

            var view = _mediator.View.InputSettingsView;
            view.Blocker.SetActive(parameter.IsActive);
            view.ListenForKey.SetActive(parameter.IsActive);
        }
    }

    public class ChangeListenForKeyTextStateCommandSignal : ISignal
    {
        public readonly bool IsActive;

        public ChangeListenForKeyTextStateCommandSignal(bool isActive)
        {
            IsActive = isActive;
        }
    }
}