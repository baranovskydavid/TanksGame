using Common.Scripts.Installers;
using Common.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Factories;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_2_Hangar.Scripts.Mediators;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scenes.Scene_2_Hangar.Scripts.Commands.TanksListPanel
{
    public class InstantiatePreviewTankCommand : ICommand
    {
        private readonly InstantiateGameObjectFactory _factory;
        private readonly TanksSettings.Settings _tanks;
        private readonly TanksListPanelMediator _mediator;
        private readonly GameModel _model;

        public InstantiatePreviewTankCommand(InstantiateGameObjectFactory factory, TanksSettings.Settings tanks, TanksListPanelMediator mediator, GameModel model)
        {
            _factory = factory;
            _tanks = tanks;
            _mediator = mediator;
            _model = model;
        }

        public void Execute()
        {
            if(_model.SelectedTank != null) Object.Destroy(_model.SelectedTank);
            if (_model.HangarIsEmpty) return;
            
            var tank = _factory.Create(_tanks.TanksList[_model.SelectedTankId].MainInfo.PhysicTank, _mediator.View.TankParent);
            _model.SelectedTank = tank;

            var view = tank.GetComponent<TankView>();
            view.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _mediator.OnTankChanged(view);
        }
    }

    public class InstantiatePreviewTankCommandSignal : ISignal { }
}