using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerGameplay
{
    public class ControlPlayerGameplayCommand : ITickable
    {
        private readonly SignalBus _signal;

        public ControlPlayerGameplayCommand(SignalBus signal)
        {
            _signal = signal;
        }

        public void Tick()
        {
            _signal.Fire<UpdateSpeedometerDataCommandSignal>();
            _signal.Fire<UpdateDistancemeterDataCommandSignal>();
            _signal.Fire<UpdatePointPositionCommandSignal>();
        }
    }
}