using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Mediators;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Restore_Password_Panel
{
    public class SendRestorePasswordRequestCommand : ICommand
    {
        public void Execute()
        {
        }
    }

    public class SendRestorePasswordRequestCommandSignal : ISignal { }
}