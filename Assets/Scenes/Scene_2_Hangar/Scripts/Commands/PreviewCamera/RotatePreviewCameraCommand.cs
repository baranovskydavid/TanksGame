using Common.Scripts.Models;
using Plugins.Upgraded_Math;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_2_Hangar.Scripts.Installers;
using Scenes.Scene_2_Hangar.Scripts.Mediators;
using UnityEngine;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.PreviewCamera
{
    public class RotatePreviewCameraCommand : ICommand
    {
        private readonly PreviewCameraSettings.Settings _settings;
        private readonly SettingsModel _model;
        private readonly Transform _transform;
        
        public RotatePreviewCameraCommand(PreviewCameraSettings.Settings settings, SettingsModel model,PreviewCameraMediator mediator)
        {
            _settings = settings;
            _model = model;
            _transform = mediator.View.transform;
        }

        public void Execute()
        {
            var angleX = UpgradedMath.ClampAngle(_transform.eulerAngles.x + Input.GetAxis("Mouse Y") * _model.MouseSensitivity * _model.MouseVerticalInversion * Time.fixedDeltaTime, _settings.MinAngleX, _settings.MaxAngleX);
            var angleY = _transform.eulerAngles.y + Input.GetAxis("Mouse X") * _model.MouseSensitivity * Time.fixedDeltaTime;
            _transform.eulerAngles = new Vector3(angleX, angleY, 0);
        }
    }

    public class RotatePreviewCameraCommandSignal : ISignal {}
}