using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Installers;
using Scenes.Scene_1_Authorization.Scripts.Mediators;
using Scenes.Scene_1_Authorization.Scripts.Views;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Additional_Info_Panel
{
    public class ShowAdditionalInfoPanelCommand : ICommandWithParameters
    {
        private readonly AuthorizationPanelMediator _mediator;
        private readonly AuthorizationPanel.Settings _settings;

        public ShowAdditionalInfoPanelCommand(AuthorizationPanelMediator mediator, AuthorizationPanel.Settings settings)
        {
            _mediator = mediator;
            _settings = settings;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (ShowAdditionalInfoPanelCommandSignal) signal;
            var panelView = _mediator.View.AdditionalInfoPanelView;
            var buttonView = parameter.View;
            
            panelView.Text_Description.text = buttonView.Description;
            panelView.transform.position = buttonView.transform.position + _settings.AdditionalInfoPanelOffset;
            panelView.gameObject.SetActive(true);
        }
    }

    public class ShowAdditionalInfoPanelCommandSignal : ISignal
    {
        public readonly AdditionalInfoButtonView View;

        public ShowAdditionalInfoPanelCommandSignal(AdditionalInfoButtonView view)
        {
            View = view;
        }
    }
}