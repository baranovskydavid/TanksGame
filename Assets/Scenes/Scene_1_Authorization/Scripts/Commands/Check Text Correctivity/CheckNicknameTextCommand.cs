using System.Linq;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Installers;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Check_Text_Correctivity
{
    public class CheckNicknameTextCommand : ICommandWithParameters
    {
        private readonly AuthorizationPanel.Settings _settings;
        private readonly AuthorizationPanelMediator _mediator;

        public CheckNicknameTextCommand(AuthorizationPanel.Settings settings, AuthorizationPanelMediator mediator)
        {
            _settings = settings;
            _mediator = mediator;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (CheckNicknameTextCommandSignal) signal;
            var text = parameter.Text;

            foreach (var word in _settings.ProhibitedWords)
            {
                if (text.Contains(word))
                {
                    _mediator.NicknameCheckingResult(_settings.NicknameUseProhibitedWords);
                    return;
                }
            }

            foreach (var symbol in text)
            {
                if (!_settings.NicknameSymbols.Contains(symbol))
                {
                    _mediator.NicknameCheckingResult(_settings.NicknameUseProhibitedSymbols);
                    return;
                }
            }

            _mediator.NicknameCheckingResult(text.Length < _settings.MinNicknameLength ? _settings.NicknameSmall : "");
        }
    }

    public class CheckNicknameTextCommandSignal : ISignal
    {
        public readonly string Text;

        public CheckNicknameTextCommandSignal(string text)
        {
            Text = text;
        }
    }
}