using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Restore_Password_Panel
{
    public class SendRestorePasswordRequestCommand : ICommand
    {
        private RestorePasswordPanelMediator _mediator;

        public SendRestorePasswordRequestCommand(RestorePasswordPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute()
        {
        }
    }

    public class SendRestorePasswordRequestCommandSignal : ISignal
    {
    }
}