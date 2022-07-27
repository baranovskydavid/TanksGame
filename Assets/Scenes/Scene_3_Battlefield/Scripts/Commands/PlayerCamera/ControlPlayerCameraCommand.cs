using Common.Scripts.Models;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera
{
    public class ControlPlayerCameraCommand : IFixedTickable
    {
        private readonly SignalBus _signal;
        private readonly GameModel _gameModel;

        public ControlPlayerCameraCommand(SignalBus signal, GameModel gameModel)
        {
            _signal = signal;
            _gameModel = gameModel;
        }

        public void FixedTick()
        {
            _signal.Fire<MovelayerCameraToTargetCommandSignal>();
            if (_gameModel.IsPaused) return;
            _signal.Fire<RotatePlayerCameraCommandSignal>();
            _signal.Fire<ZoomPlayerCameraCommandSignal>();
            _signal.Fire<GetHitPointCommandSignal>();
        }
    }
}