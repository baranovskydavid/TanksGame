using Common.Scripts.Models;
using Plugins.Upgraded_Math;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_3_Battlefield.Scripts.Installers;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera
{
    public class RotateCameraCommand : ICommand
    {
        private readonly PlayerCameraSettings.Settings _settings;
        private readonly SettingsModel _model;
        private readonly Transform _pivot;


        public RotateCameraCommand(PlayerCameraSettings.Settings settings, SettingsModel settingsModel ,PlayerTankModel model)
        {
            _settings = settings;
            _model = settingsModel;
            _pivot = model.PlayerCameraView.transform;
        }

        public void Execute()
        {
            var angleX = UpgradedMath.ClampAngle(_pivot.eulerAngles.x + Input.GetAxis("Mouse Y") * _model.MouseSensitivity * _model.MouseVerticalInversion * Time.fixedDeltaTime, _settings.MinAngleX, _settings.MaxAngleX);
            var angleY = _pivot.eulerAngles.y + Input.GetAxis("Mouse X") * _model.MouseSensitivity * Time.fixedDeltaTime;
            _pivot.eulerAngles = new Vector3(angleX, angleY, 0);
        }
    }

    public class RotatePlayerCameraCommandSignal : ISignal { }
}