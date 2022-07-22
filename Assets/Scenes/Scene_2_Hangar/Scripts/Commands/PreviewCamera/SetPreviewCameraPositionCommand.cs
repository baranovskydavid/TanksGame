using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_2_Hangar.Scripts.Mediators;
using UnityEngine;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.PreviewCamera
{
    public class SetPreviewCameraPositionCommand : ICommandWithParameters
    {
        private readonly Transform _pivot;

        public SetPreviewCameraPositionCommand(PreviewCameraMediator mediator)
        {
            _pivot = mediator.View.transform;
        }

        public void Execute(ISignal signal)
        {
            var parameter = (SetPreviewCameraPositionCommandSignal) signal;
            _pivot.position = parameter.Position;
        }
    }

    public class SetPreviewCameraPositionCommandSignal : ISignal
    {
        public readonly Vector3 Position;

        public SetPreviewCameraPositionCommandSignal(Vector3 position)
        {
            Position = position;
        }
    }
}