using System;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_2_Hangar.Scripts.Installers;
using Scenes.Scene_2_Hangar.Scripts.Mediators;
using UnityEngine;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.PreviewCamera
{
    public class ZoomPreviewCameraCommand : ICommand
    {
        private readonly PreviewCameraSettings.Settings _settings;
        private readonly Transform _transform;
        
        public ZoomPreviewCameraCommand(PreviewCameraSettings.Settings settings, PreviewCameraMediator mediator)
        {
            _settings = settings;
            _transform = mediator.View.Camera.transform;
        }
        public void Execute()
        {
            var deltaLocalPosition = new Vector3(0,0,-Input.GetAxis("Mouse ScrollWheel") * _settings.ZoomSpeed * Time.fixedDeltaTime);
            var localPosition = _transform.localPosition + deltaLocalPosition;
            _transform.localPosition = new Vector3(localPosition.x, localPosition.y, Mathf.Clamp(localPosition.z, _settings.MinLocalPositionZ, _settings.MaxLocalPositionZ));
        }
    }

    public class ZoomPreviewCameraCommandSignal : ISignal
    {
    }
}