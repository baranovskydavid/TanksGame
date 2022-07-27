using Scenes.Scene_0_Main.Scripts.Interfaces;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.Initialization
{
    public class InitializeGameCommand : ICommand
    {
        private readonly SignalBus _signal;

        public InitializeGameCommand(SignalBus signal)
        {
            _signal = signal;
        }

        public void Execute()
        {
            _signal.Fire<InstantiatePlayerTankCommandSignal>();
            _signal.Fire<SetupPlayerTankCommandSignal>();
            _signal.Fire<InstantiatePlayerCameraCommandSignal>();
        }
    }

    public class InitializeGameCommandSignal : ISignal { }
}