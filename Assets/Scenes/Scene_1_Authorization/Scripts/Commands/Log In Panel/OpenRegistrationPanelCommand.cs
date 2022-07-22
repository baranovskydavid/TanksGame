using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Panel
{
    public class OpenRegistrationPanelCommand : ICommand
    {
        private readonly LogInPanelMediator _mediator;

        public OpenRegistrationPanelCommand(LogInPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View;

            view.InputField_Login.text = "";
            view.InputField_Password.text = "";
            
            view.Panel_Registration.SetActive(true);
            view.gameObject.SetActive(false);
        }
    }

    public class OpenRegistrationPanelCommandSignal : ISignal
    {
    }
}