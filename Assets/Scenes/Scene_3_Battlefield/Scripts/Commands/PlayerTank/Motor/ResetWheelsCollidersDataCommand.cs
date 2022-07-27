using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class ResetWheelsCollidersDataCommand : ICommand
    {
        private readonly PlayerTankModel _tankModel;

        public ResetWheelsCollidersDataCommand(PlayerTankModel tankModel)
        {
            _tankModel = tankModel;
        }

        public void Execute()
        {
            _tankModel.LeftWheelsCollidersData.ChangeWheelColliderData();
            _tankModel.RightWheelsCollidersData.ChangeWheelColliderData();
        }
    }

    public class ResetWheelsCollidersDataCommandSignal : ISignal { }
}