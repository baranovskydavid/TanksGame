using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Installers;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands
{
    public class SetAuthorizationPanelDataCommand : ICommand
    {
        private readonly AuthorizationPanelMediator _mediator;
        private readonly AuthorizationPanel.Settings _settings;

        public SetAuthorizationPanelDataCommand(AuthorizationPanelMediator mediator, AuthorizationPanel.Settings settings)
        {
            _mediator = mediator;
            _settings = settings;
        }

        public void Execute()
        {
            var view = _mediator.View;
            view.Image_Background.sprite = _settings.Background;
        }
    }
    
    public class SetAuthorizationPanelDataCommandSignal : ISignal {}
}
