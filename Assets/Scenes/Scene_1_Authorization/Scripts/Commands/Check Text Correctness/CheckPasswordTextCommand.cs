using System.Linq;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Installers;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Check_Text_Correctness
{
    public class CheckPasswordTextCommand : ICommandWithParameters
    {
        private readonly AuthorizationPanel.Settings _settings;
        private readonly AuthorizationPanelMediator _mediator;

        public CheckPasswordTextCommand(AuthorizationPanel.Settings settings, AuthorizationPanelMediator mediator)
        {
            _settings = settings;
            _mediator = mediator;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (CheckPasswordTextCommandSignal) signal;
            var text = parameter.Text;
            
            if (text.Any(symbol => !_settings.PasswordSymbols.Contains(symbol))) {
                _mediator.PasswordCheckingResult(_settings.PasswordUseProhibitedSymbols);
                return;
            }
            
            _mediator.PasswordCheckingResult(parameter.Text.Length < _settings.MinPasswordLength ? _settings.PasswordSmall : "");
        }
    }

    public class CheckPasswordTextCommandSignal : ISignal
    {
        public readonly string Text;

        public CheckPasswordTextCommandSignal(string text)
        {
            Text = text;
        }
    }
}