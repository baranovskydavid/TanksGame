using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;

namespace Common.Scripts.Commands
{
    public class ChangeCursorStateCommand : ICommandWithParameters
    {

        public void Execute(ISignal signal)
        {
            var parameter = (ChangeCursorStateCommandSignal) signal;

            Cursor.visible = parameter.IsVisible;
            Cursor.lockState = parameter.IsVisible ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }

    public class ChangeCursorStateCommandSignal : ISignal
    {
        public readonly bool IsVisible;

        public ChangeCursorStateCommandSignal(bool isVisible = true)
        {
            IsVisible = isVisible;
        }
    }
}