using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands
{
    public class ChangeGameModeCommand : ICommandWithParameters
    {
        private readonly GameModesMediator _mediator;

        public ChangeGameModeCommand(GameModesMediator mediator)
        {
            _mediator = mediator;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (ChangeGameModeCommandSignal) signal;
            var view = _mediator.View;
            
            view.Panel_Online.SetActive(parameter.IsPlayOnline);
            view.Panel_Offline.SetActive(!parameter.IsPlayOnline);

            view.Button_Online.image.color = view.Panel_Online.activeSelf ? view.Color_SelectedButton : view.Color_DeselectedButton;
            view.Button_Offline.image.color = view.Panel_Offline.activeSelf ? view.Color_SelectedButton : view.Color_DeselectedButton;
        }
    }

    public class ChangeGameModeCommandSignal : ISignal
    {
        public readonly bool IsPlayOnline;

        public ChangeGameModeCommandSignal(bool isPlayOnline = true)
        {
            IsPlayOnline = isPlayOnline;
        }
    }
}
