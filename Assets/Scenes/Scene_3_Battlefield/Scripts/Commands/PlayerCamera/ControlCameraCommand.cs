using Common.Scripts.Models;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera
{
    public class ControlCameraCommand : IFixedTickable
    {
        private readonly SignalBus _signal;
        private readonly GameModel _gameModel;

        public ControlCameraCommand(SignalBus signal, GameModel gameModel)
        {
            _signal = signal;
            _gameModel = gameModel;
        }

        public void FixedTick()
        {
            _signal.Fire<MoveCameraToTargetCommandSignal>();
            if (_gameModel.IsPaused) return;
            _signal.Fire<RotateCameraCommandSignal>();
            _signal.Fire<ZoomCameraCommandSignal>();
            _signal.Fire<GetHitPointCommandSignal>();
        }
    }
}