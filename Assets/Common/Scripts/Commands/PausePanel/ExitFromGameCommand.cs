using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;

namespace Common.Scripts.Commands.PausePanel
{
    public class ExitFromGameCommand : ICommand
    {
        public void Execute()
        {
            Application.Quit();
        }
    }

    public class ExitFromGameCommandSignal : ISignal
    {
    }
}