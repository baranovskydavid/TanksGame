using Common.Scripts.Installers;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_2_Hangar.Scripts.Json;

namespace Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Offline
{
    public class CreateOfflinePlayerDataCommand : ICommand
    {
        private readonly TanksSettings.Settings _settings;
        private readonly GameModel _model;

        public CreateOfflinePlayerDataCommand(TanksSettings.Settings settings, GameModel model)
        {
            _settings = settings;
            _model = model;
        }

        public void Execute()
        {
            var playerData = new PlayerData();
            
            foreach (var unused in _settings.TanksList) {
                playerData.Tanks.Add(new Tank{tankStatus = Tank.TankStatus.Bought}); }

            _model.PlayerData = playerData;
        }
    }

    public class CreateDefaultPlayerDataCommandSignal : ISignal { }
}