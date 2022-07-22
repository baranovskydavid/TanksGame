using System.IO;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;

namespace Common.Scripts.Commands.PlayerData
{
    public class SaveOfflinePlayerDataCommand : ICommand
    {
        private readonly GameModel _model;

        public SaveOfflinePlayerDataCommand(GameModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            var path = Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder + MainConstants.JsonPaths.PlayerDataFile;
            var json = JsonUtility.ToJson(_model.PlayerData);
            File.WriteAllText(path, json);
        }
    }

    public class SaveOfflinePlayerDataCommandSignal : ISignal
    {
    }
}