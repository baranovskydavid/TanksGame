using System.Threading.Tasks;
using Scenes.Scene_0_Main.Scripts.Installers;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using UnityEngine;

namespace Scenes.Scene_0_Main.Scripts.Commands.LoadingPanels
{
    public class DestroyLoadingPanelCommand : ICommand
    {
        private readonly LoadingPanel.Settings _settings;
        private readonly MainModel _model;

        public DestroyLoadingPanelCommand(LoadingPanel.Settings settings, MainModel model)
        {
            _settings = settings;
            _model = model;
        }

        public void Execute()
        {
            WaitTimer();
        }

        private async void WaitTimer()
        {
            await Task.Delay(_settings.MillisecondsDelayAfterLoading);
            DestroyPanel();
        }

        private void DestroyPanel()
        {
            if (_model.LoadingPanelView == null) return;
            Object.Destroy(_model.LoadingPanelView.gameObject);
        }
    }
}
