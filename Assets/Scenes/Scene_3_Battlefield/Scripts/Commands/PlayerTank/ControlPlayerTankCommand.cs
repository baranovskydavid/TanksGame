using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor;
using Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Turret;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank
{
    public class ControlPlayerTankCommand : IFixedTickable
    {
        private readonly SignalBus _signal;
        private readonly SettingsModel _model;
        private readonly GameModel _gameModel;

        public ControlPlayerTankCommand(SignalBus signal, SettingsModel model, GameModel gameModel)
        {
            _signal = signal;
            _model = model;
            _gameModel = gameModel;
        }

        public void FixedTick()
        {
            Motor();
            Turret();
            _signal.Fire<ShowDebugDataCommandSignal>();
        }

        private void Turret()
        {
            _signal.Fire<RotateTurretCommandSignal>();
            _signal.Fire<RotateTrunkCommandSignal>();
            _signal.Fire<GetHitPointCommandSignal>();
        }

        private void Motor()
        {
            _signal.Fire<UpdateTankMotorInfoCommandSignal>();
            _signal.Fire<ResetWheelsCollidersDataCommandSignal>();
            
            var vertical = _model.InputManager.GetAxisValue("Movement");
            if (vertical.Equals(0)) {
                _signal.Fire(new BrakeTankCommandSignal());
            }
            else {
                _signal.Fire(new AccelerateTankCommandSignal(vertical));
            }
            
            var horizontal = _model.InputManager.GetAxisValue("Rotation");
            _signal.Fire(new RotateTankCommandSignal(horizontal, vertical));

            
           var brake = _model.InputManager.GetAxisValue("Brake");
           if (!brake.Equals(0) || _gameModel.IsPaused)
           {
                _signal.Fire(new BrakeTankCommandSignal());
           }

           _signal.Fire<UpdateTankMotorDataCommandSignal>();
           _signal.Fire(new UpdateTankVisibilityCommandSignal(horizontal));
        }
    }
}