using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Commands.SceneService;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Scripts.Commands.PausePanel
{
    public class ExitToHangarCommand : ICommand
    {
        private readonly GameModel _model;
        private readonly SignalBus _signal;

        public ExitToHangarCommand(GameModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
        }

        public void Execute()
        {
            _model.InMatch = false;
            if (SceneManager.GetActiveScene().name.Equals(MainConstants.ScenesNames.Battlefield))
            {
                _signal.Fire(new LoadSceneCommandSignal(MainConstants.ScenesNames.Hangar));
            }
        }
    }

    public class ExitToHangarCommandSignal : ISignal {}
}