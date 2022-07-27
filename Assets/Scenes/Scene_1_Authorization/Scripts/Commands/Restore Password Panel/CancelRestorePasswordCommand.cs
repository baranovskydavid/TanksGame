using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Restore_Password_Panel
{
    public class CancelRestorePasswordCommand : ICommand
    {
        private readonly RestorePasswordPanelMediator _mediator;

        public CancelRestorePasswordCommand(RestorePasswordPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View;
            
            view.InputField_Login.text = string.Empty;
            view.InputField_Password.text = string.Empty;
            
            view.Panel_LogIn.SetActive(true);
            view.gameObject.SetActive(false);
        }
    }

    public class CancelRestorePasswordCommandSignal : ISignal { }
}