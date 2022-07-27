using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_2_Hangar.Scripts.Mediators;
using Scenes.Scene_2_Hangar.Scripts.Views;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.TanksListPanel
{
    public class SelectTankCommand : ICommandWithParameters
    {
        private readonly TanksListPanelMediator _mediator;
        private readonly GameModel _model;
        private readonly SignalBus _signal;

        public SelectTankCommand(TanksListPanelMediator mediator, GameModel model, SignalBus signal)
        {
            _mediator = mediator;
            _model = model;
            _signal = signal;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (SelectPreviewTankCommandSignal) signal;
            var view = parameter.View;

            if (view != null) {
                if (_model.SelectedTankId == view.Id) return;
                _model.HangarIsEmpty = false;
                _model.SelectedTankId = view.Id;
            }
            else {
                _model.HangarIsEmpty = _mediator.View.SpawnedButtons.Count == 0;
                _model.SelectedTankId = 0;
            }
            _mediator.View.TankHeader.SetActive(true);
            _signal.Fire<InstantiatePreviewTankCommandSignal>();
        }
    }

    public class SelectPreviewTankCommandSignal : ISignal
    {
        public readonly TankPreviewView View;

        public SelectPreviewTankCommandSignal(TankPreviewView view = null)
        {
            View = view;
        }
    }
}