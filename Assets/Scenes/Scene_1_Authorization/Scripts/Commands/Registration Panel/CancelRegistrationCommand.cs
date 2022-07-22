using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Registration_Panel
{
    public class CancelRegistrationCommand : ICommand
    {
        private readonly RegistrationPanelMediator _mediator;

        public CancelRegistrationCommand(RegistrationPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute()
        {
            var view = _mediator.View;
            
            view.Panel_LogIn.SetActive(true);
            view.gameObject.SetActive(false);
        }
    }

    public class CancelRegistrationCommandSignal : ISignal {}
}