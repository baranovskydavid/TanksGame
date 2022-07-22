using System.Linq;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Installers;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Check_Text_Correctivity
{
    public class CheckEmailTextCommand : ICommandWithParameters
    {
        private readonly AuthorizationPanel.Settings _settings;
        private readonly AuthorizationPanelMediator _mediator;

        public CheckEmailTextCommand(AuthorizationPanel.Settings settings, AuthorizationPanelMediator mediator)
        {
            _settings = settings;
            _mediator = mediator;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (CheckEmailTextCommandSignal) signal;
            var text = parameter.Text;

            if (text.Contains('@') && text.Contains('.') && text.IndexOf('@') < text.LastIndexOf('.'))
            {
                _mediator.EmailCheckingResult();
                return;
            }
            
            _mediator.EmailCheckingResult(_settings.EmailIncorrect);
        }
    }

    public class CheckEmailTextCommandSignal : ISignal
    {
        public readonly string Text;

        public CheckEmailTextCommandSignal(string text)
        {
            Text = text;
        }
    }
}