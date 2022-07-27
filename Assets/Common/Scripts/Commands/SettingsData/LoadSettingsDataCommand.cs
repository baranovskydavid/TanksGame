using System.IO;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using UnityEngine;

namespace Common.Scripts.Commands.SettingsData
{
    public class LoadSettingsDataCommand : ICommand
    {
        private readonly SettingsModel _model;

        public LoadSettingsDataCommand(SettingsModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            var json = File.ReadAllText(Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder + MainConstants.JsonPaths.SettingsDataFile);
            var settingsData = JsonUtility.FromJson<Json.SettingsData>(json);
            _model.InputManager.LoadInputData();
            _model.SettingsData = settingsData;
        }
    }

    public class LoadSettingsDataCommandSignal : ISignal {}
}