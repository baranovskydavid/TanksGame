using System.Collections.Generic;
using Common.Scripts.Commands;
using Common.Scripts.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.PreviewCamera
{
    public class ControlPreviewCameraCommand : IFixedTickable
    {
        private readonly SignalBus _signal;
        private bool _isMoving;

        public ControlPreviewCameraCommand(SignalBus signal)
        {
            _signal = signal;
        }

        public void FixedTick()
        {
            if (Input.GetMouseButton(0) && !_isMoving && GetHitOnUiObjects() == 0)
            {
                _signal.Fire(new ChangeCursorStateCommandSignal(false));
                _isMoving = true;
            }
            
            if (!Input.GetMouseButton(0) && _isMoving)
            {
                _signal.Fire(new ChangeCursorStateCommandSignal(true));
                _isMoving = false;
            }

            if (!_isMoving) return;
            _signal.Fire<RotatePreviewCameraCommandSignal>();
            _signal.Fire<ZoomPreviewCameraCommandSignal>();
            _signal.Fire<CheckPreviewCameraCollisionsCommandSignal>();
        }
        
        private int GetHitOnUiObjects()
        {
            var pointer = new PointerEventData(EventSystem.current) {position = Input.mousePosition};
            var uiObjectsHit = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, uiObjectsHit);
            return uiObjectsHit.Count;
        }
    }
}