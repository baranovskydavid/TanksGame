using Common.Scripts.Installers;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class AccelerateTankCommand : ICommandWithParameters
    {
        private readonly PlayerTankModel _model;
        private readonly TankSettings _settings;
        private readonly SignalBus _signal;
        private float _averageSpeed;

        public AccelerateTankCommand(PlayerTankModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
            _settings = model.Settings;
        }

        public void Execute(ISignal signal)
        {
            var vertical = ((AccelerateTankCommandSignal)signal).Vertical;

            _averageSpeed = _model.MotorInfo.AverageSpeed;
            if (vertical > 0 && _averageSpeed > _settings.Motor.MaxForwardSpeed || vertical < 0 && _averageSpeed < _settings.Motor.MaxBackwardSpeed) {
                return;
            }
            if (vertical > 0 && _averageSpeed < 0 || vertical < 0 && _averageSpeed > 0) {
                _signal.Fire<BrakeTankCommandSignal>();
                return;
            }

            _model.LeftWheelsCollidersData.ChangeWheelColliderData(_settings.Motor.MotorTorque * vertical);
            _model.RightWheelsCollidersData.ChangeWheelColliderData(_settings.Motor.MotorTorque * vertical);
        }
    }

    public class AccelerateTankCommandSignal : ISignal
    {
        public readonly float Vertical;

        public AccelerateTankCommandSignal(float vertical)
        {
            Vertical = vertical;
        }
    }
}