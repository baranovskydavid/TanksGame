using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class BrakeTankCommand : ICommand
    {
        private readonly PlayerTankModel _model;

        public BrakeTankCommand(PlayerTankModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            _model.Rotation = Quaternion.Euler(Vector3.zero);
            _model.LeftWheelsCollidersData.ChangeWheelColliderData(0, _model.Settings.Motor.BrakeTorque);
            _model.RightWheelsCollidersData.ChangeWheelColliderData(0, _model.Settings.Motor.BrakeTorque);
        }
    }

    public class BrakeTankCommandSignal : ISignal { }
}