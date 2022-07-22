using System.IO;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;

namespace Common.Scripts.Commands.PlayerData
{
    public class LoadOfflinePlayerDataCommand : ICommand
    {
        private readonly GameModel _model;

        public LoadOfflinePlayerDataCommand(GameModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            var json = File.ReadAllText(Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder + MainConstants.JsonPaths.PlayerDataFile);
            var playerData = JsonUtility.FromJson<Scenes.Scene_2_Hangar.Scripts.Json.PlayerData>(json);
            _model.PlayerData = playerData;
        }
    }

    public class LoadOfflinePlayerDataCommandSignal : ISignal
    {
    }
}