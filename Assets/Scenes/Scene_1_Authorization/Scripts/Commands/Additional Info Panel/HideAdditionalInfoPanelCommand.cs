using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Additional_Info_Panel
{
    public class HideAdditionalInfoPanelCommand : ICommand
    {
        private readonly AuthorizationPanelMediator _mediator;

        public HideAdditionalInfoPanelCommand(AuthorizationPanelMediator mediator)
        {
            _mediator = mediator;
        }
        
        public void Execute()
        {
            var view = _mediator.View.AdditionalInfoPanelView;

            view.Text_Description.text = "";
            view.gameObject.SetActive(false);
        }
    }

    public class HideAdditionalInfoPanelCommandSignal : ISignal { }
}