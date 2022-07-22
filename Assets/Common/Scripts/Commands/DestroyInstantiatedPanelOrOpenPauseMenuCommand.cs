using Common.Scripts.Commands.PausePanel;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Scripts.Commands
{
    public class DestroyInstantiatedPanelOrOpenPauseMenuCommand : ICommand
    {
        private readonly GameModel _model;
        private readonly SignalBus _signal;

        public DestroyInstantiatedPanelOrOpenPauseMenuCommand(GameModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
        }

        public void Execute()
        {
            if (_model.InstantiatedPanel == null) {
                _signal.Fire<InstantiatePausePanelCommandSignal>();
                _signal.Fire(new ChangeCursorStateCommandSignal());
            }
            else {
                Object.Destroy(_model.InstantiatedPanel);
                if (SceneManager.GetSceneByName(MainConstants.ScenesNames.Battlefield).isLoaded) {
                    _signal.Fire(new ChangeCursorStateCommandSignal(false));
                }
            }
        }
    }
}