using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Panel
{
    public class LogInCommand : ICommand
    {
        private readonly LogInPanelMediator _mediator;

        public LogInCommand(LogInPanelMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute()
        {
            
        }
    }

    public class LogInCommandSignal : ISignal
    {
    }
}