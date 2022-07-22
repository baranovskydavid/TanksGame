using Common.Scripts.Signals;
using Cysharp.Threading.Tasks;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Scripts.Commands
{
    public class BindEscapeKeyCommand : ICommand
    {
        private readonly SignalBus _signal;
        private bool _waitingForKey;

        public BindEscapeKeyCommand(SignalBus signal)
        {
            _signal = signal;
        }

        public void Execute()
        {
            var activeSceneName = SceneManager.GetActiveScene().name;
            if (activeSceneName.Equals(MainConstants.ScenesNames.Hangar) || activeSceneName.Equals(MainConstants.ScenesNames.Battlefield))
            {                
                if (_waitingForKey)
                {
                    return;
                }

                _waitingForKey = true;
                WaitingForEscapeKey();
                return;
            }
            _waitingForKey = false;
        }

        private async void WaitingForEscapeKey()
        {
            while (_waitingForKey)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    _signal.Fire<EscapeKeyClickedCommandSignal>();
                }

                await UniTask.Yield();
            }
        }
    }
}