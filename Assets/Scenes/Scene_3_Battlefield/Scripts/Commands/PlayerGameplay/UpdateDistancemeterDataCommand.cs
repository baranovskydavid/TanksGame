﻿using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Mediators;
using Scenes.Scene_3_Battlefield.Scripts.Models;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerGameplay
{
    public class UpdateDistancemeterDataCommand : ICommand
    {
        private readonly PlayerGameplayMediator _mediator;
        private readonly PlayerTankModel _model;

        public UpdateDistancemeterDataCommand(PlayerGameplayMediator mediator, PlayerTankModel model)
        {
            _mediator = mediator;
            _model = model;
        }

        public void Execute()
        {
            if(_mediator.View == null) return;
            _mediator.View.Text_Distancemeter.text = _model.CameraHitPointDistance.ToString();
        }
    }

    public class UpdateDistancemeterDataCommandSignal : ISignal { }
}