using System.IO;
using Scenes.Scene_0_Main.Scripts.Constants;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Common.Scripts.Commands.SettingsData
{
    public class SetupSettingsCommand : ICommand
    {
        private readonly SignalBus _signal;

        public SetupSettingsCommand(SignalBus signal)
        {
            _signal = signal;
        }

        public void Execute()
        {
            var path = Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder;
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            if (File.Exists(path + MainConstants.JsonPaths.SettingsDataFile)) {
                _signal.Fire<LoadSettingsDataCommandSignal>();
            }
            else {
                _signal.Fire<CreateDefaultSettingsDataCommandSignal>();
                _signal.Fire<SaveSettingsDataCommandSignal>();
            }
            
            _signal.Fire<SetupGraphicSettingsCommandSignal>();
            _signal.Fire<SetupInputSettingsCommandSignal>();
        }
    }
}