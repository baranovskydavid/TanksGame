using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Panel
{
    public class OpenRestorePasswordPanelCommand : ICommand
    {
        private readonly LogInPanelMediator _mediator;

        public OpenRestorePasswordPanelCommand(LogInPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View;
            
            view.InputField_Login.text = string.Empty;
            view.InputField_Password.text = string.Empty;
            
            view.Panel_RestorePassword.SetActive(true);
            view.gameObject.SetActive(false);
        }
    }

    public class OpenRestorePasswordPanelCommandSignal : ISignal { }
}