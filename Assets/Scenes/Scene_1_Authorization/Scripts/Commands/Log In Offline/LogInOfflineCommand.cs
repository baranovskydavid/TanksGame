using System.IO;
using Common.Scripts.Commands.PlayerData;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Commands.SceneService;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Offline
{
    public class LogInOfflineCommand : ICommand
    {
        private readonly GameModel _model;
        private readonly SignalBus _signal;

        public LogInOfflineCommand(GameModel model, SignalBus signal)
        {
            _model = model;
            _signal = signal;
        }

        public void Execute()
        {
            _model.NetworkGameMode = NetworkGameMode.Offline;
            
            var path = Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder;
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            if (File.Exists(path + MainConstants.JsonPaths.PlayerDataFile)) {
                _signal.Fire<LoadOfflinePlayerDataCommandSignal>();
            }
            else {
                _signal.Fire<CreateDefaultPlayerDataCommandSignal>();
                _signal.Fire<SaveOfflinePlayerDataCommandSignal>();
            }
            
            _signal.Fire(new LoadSceneCommandSignal(MainConstants.ScenesNames.Hangar));
        }
    }

    public class LogInOfflineCommandSignal : ISignal { }
}