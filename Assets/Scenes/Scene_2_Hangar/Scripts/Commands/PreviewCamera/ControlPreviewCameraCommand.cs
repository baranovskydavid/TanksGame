using System.Collections.Generic;
using Common.Scripts.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.PreviewCamera
{
    public class ControlPreviewCameraCommand : IFixedTickable
    {
        private readonly SignalBus _signal;
        private readonly GameModel _model;

        public ControlPreviewCameraCommand(SignalBus signal, GameModel model)
        {
            _signal = signal;
            _model = model;
        }

        public void FixedTick()
        {
            if (!Input.GetMouseButton(0) || GetHitOnUiObjects() != 0) return;
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