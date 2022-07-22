using System.IO;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using UnityEngine;

namespace Common.Scripts.Commands.SettingsData
{
    public class SaveSettingsDataCommand : ICommand
    {
        private readonly SettingsModel _model;

        public SaveSettingsDataCommand(SettingsModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            var path = Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder + MainConstants.JsonPaths.SettingsDataFile;
            var json = JsonUtility.ToJson(_model.SettingsData);
            File.WriteAllText(path, json);
        }
    }

    public class SaveSettingsDataCommandSignal : ISignal
    {
    }
}