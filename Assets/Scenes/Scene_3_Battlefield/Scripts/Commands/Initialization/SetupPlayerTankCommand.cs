using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;


namespace Scenes.Scene_3_Battlefield.Scripts.Commands.Initialization
{
    public class SetupPlayerTankCommand : ICommand
    {
        private readonly TankView _view;

        public SetupPlayerTankCommand(PlayerTankModel model)
        {
            _view = model.TankView;
        }

        public void Execute()
        {
            _view.Rigidbody.centerOfMass = _view.CenterOfMass.localPosition;
        }
    }

    public class SetupPlayerTankCommandSignal : ISignal
    {
    }
}