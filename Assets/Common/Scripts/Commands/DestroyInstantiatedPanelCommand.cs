using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Object = UnityEngine.Object;

namespace Common.Scripts.Commands
{
    public class DestroyInstantiatedPanelCommand : ICommand
    {
        private readonly GameModel _model;

        public DestroyInstantiatedPanelCommand(GameModel model)
        {
            _model = model;
        }

        public void Execute()
        {
            Object.Destroy(_model.InstantiatedPanel);
        }
    }

    public class DestroyInstantiatedPanelCommandSignal : ISignal
    {
    }
}