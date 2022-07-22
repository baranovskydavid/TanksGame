using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Installers;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera
{
    public class ZoomCameraCommand : ICommand
    {
        private readonly PlayerCameraSettings.Settings _settings;
        private readonly Transform _camera;
        private Vector3 _offset;
        private int _offsetId;

        public ZoomCameraCommand(PlayerCameraSettings.Settings settings, PlayerTankModel model)
        {
            _settings = settings;
            _camera = model.PlayerCameraView.Camera.transform;
            
            _offsetId = _settings.DefaultOffsetId;
            _offset = _settings.Offsets[_offsetId];
        }

        public void Execute()
        {
            var mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");

            if (mouseScrollWheel != 0)
            {
                if (mouseScrollWheel > 0)
                {
                    if (_offsetId > 0)
                    {
                        _offsetId--;
                        _offset = _settings.Offsets[_offsetId];
                    }
                }
                else
                {
                    if (_offsetId < _settings.Offsets.Length - 1)
                    {
                        _offsetId++;
                        _offset = _settings.Offsets[_offsetId];
                    }
                }
            }

            _camera.localPosition = Vector3.Lerp(_camera.localPosition, _offset, _settings.ZoomingSpeed * Time.fixedDeltaTime);
        }
    }

    public class ZoomCameraCommandSignal : ISignal { }
}