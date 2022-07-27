using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;

namespace Common.Scripts.Commands.PausePanel
{
    public class SetupPausePanelCommand : ICommand
    {
        private readonly GameModel _model;
        private readonly PausePanelMediator _mediator;

        public SetupPausePanelCommand(GameModel model, PausePanelMediator mediator)
        {
            _model = model;
            _mediator = mediator;
        }

        public void Execute()
        {
            _mediator.View.ExitToHangar.gameObject.SetActive(_model.InMatch);
        }
    }

    public class SetupPausePanelCommandSignal : ISignal {}
}