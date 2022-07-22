using Common.Scripts.Mediators;
using Scenes.Scene_3_Battlefield.Scripts.Commands.Initialization;
using Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera;
using Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerGameplay;
using Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank;
using Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor;
using Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Turret;
using Scenes.Scene_3_Battlefield.Scripts.Factories;
using Scenes.Scene_3_Battlefield.Scripts.Mediators;
using Scenes.Scene_3_Battlefield.Scripts.Models;
using Zenject;
using GetHitPointCommand = Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera.GetHitPointCommand;
using GetHitPointCommandSignal = Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerCamera.GetHitPointCommandSignal;

namespace Scenes.Scene_3_Battlefield.Scripts.Installers
{
    public class BattlefieldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallServices();
            InstallViews();
            InstallModels();
            InstallSignals();
            InstallViewSignals();
            InstallMediators();
            InstallCommandSignals();
        }

        private void InstallServices()
        {
        }

        private void InstallViews()
        {
            Container.Bind<InstantiateGameObjectFactory>()
                .AsSingle();
        }

        private void InstallModels()
        {
            Container.Bind<PlayerTankModel>()
                .AsSingle(); 
        }

        private void InstallSignals()
        {
        }

        private void InstallViewSignals()
        {
        }

        private void InstallMediators()
        {
            Container.BindInterfacesAndSelfTo<ContentViewMediator>()
            .AsSingle();
            Container.BindInterfacesAndSelfTo<GameManagerMediator>()
            .AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerGameplayMediator>()
            .AsSingle();
        }

        private void InstallCommandSignals()
        {
            #region Initializing
            Container.DeclareSignal<InitializeGameCommandSignal>();
            Container.BindSignal<InitializeGameCommandSignal>()
                .ToMethod<InitializeGameCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<InstantiatePlayerTankCommandSignal>();
            Container.BindSignal<InstantiatePlayerTankCommandSignal>()
                .ToMethod<InstantiatePlayerTankCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SetupPlayerTankCommandSignal>();
            Container.BindSignal<SetupPlayerTankCommandSignal>()
                .ToMethod<SetupPlayerTankCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<InstantiatePlayerCameraCommandSignal>();
            Container.BindSignal<InstantiatePlayerCameraCommandSignal>()
                .ToMethod<InstantiatePlayerCameraCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Player Camera
            Container.Bind<IFixedTickable>().To<ControlCameraCommand>()
                .AsCached();
            
            Container.DeclareSignal<MoveCameraToTargetCommandSignal>();
            Container.BindSignal<MoveCameraToTargetCommandSignal>()
                .ToMethod<MoveCameraToTargetCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<RotateCameraCommandSignal>();
            Container.BindSignal<RotateCameraCommandSignal>()
                .ToMethod<RotateCameraCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ZoomCameraCommandSignal>();
            Container.BindSignal<ZoomCameraCommandSignal>()
                .ToMethod<ZoomCameraCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<GetHitPointCommandSignal>();
            Container.BindSignal<GetHitPointCommandSignal>()
                .ToMethod<GetHitPointCommand>(signal => signal.Execute)
                .FromNew();
            #endregion

            #region Player Tank
            Container.Bind<IFixedTickable>().To<ControlPlayerTankCommand>()
                .AsCached();

            #region Motor
            Container.DeclareSignal<UpdateTankMotorInfoCommandSignal>();
            Container.BindSignal<UpdateTankMotorInfoCommandSignal>()
                .ToMethod<UpdateTankMotorInfoCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ResetWheelsCollidersDataCommandSignal>();
            Container.BindSignal<ResetWheelsCollidersDataCommandSignal>()
                .ToMethod<ResetWheelsCollidersDataCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<AccelerateTankCommandSignal>();
            Container.BindSignal<AccelerateTankCommandSignal>()
                .ToMethod<AccelerateTankCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<RotateTankCommandSignal>();
            Container.BindSignal<RotateTankCommandSignal>()
                .ToMethod<RotateTankCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<BrakeTankCommandSignal>();
            Container.BindSignal<BrakeTankCommandSignal>()
                .ToMethod<BrakeTankCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<UpdateTankMotorDataCommandSignal>();
            Container.BindSignal<UpdateTankMotorDataCommandSignal>()
                .ToMethod<UpdateTankMotorDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<UpdateTankVisibilityCommandSignal>();
            Container.BindSignal<UpdateTankVisibilityCommandSignal>()
                .ToMethod<UpdateTankVisibilityCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<UpdateStaticWheelsRotationCommandSignal>();
            Container.BindSignal<UpdateStaticWheelsRotationCommandSignal>()
                .ToMethod<UpdateStaticWheelsRotationCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<UpdateWheelsRotationAndPositionCommandSignal>();
            Container.BindSignal<UpdateWheelsRotationAndPositionCommandSignal>()
                .ToMethod<UpdateWheelsRotationAndPositionCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<UpdateTrackTextureOffsetCommandSignal>();
            Container.BindSignal<UpdateTrackTextureOffsetCommandSignal>()
                .ToMethod<UpdateTrackTextureOffsetCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Turret
            Container.DeclareSignal<RotateTurretCommandSignal>();
            Container.BindSignal<RotateTurretCommandSignal>()
                .ToMethod<RotateTurretCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<RotateTrunkCommandSignal>();
            Container.BindSignal<RotateTrunkCommandSignal>()
                .ToMethod<RotateTrunkCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<Commands.PlayerTank.Turret.GetHitPointCommandSignal>();
            Container.BindSignal<Commands.PlayerTank.Turret.GetHitPointCommandSignal>()
                .ToMethod<Commands.PlayerTank.Turret.GetHitPointCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            Container.DeclareSignal<ShowDebugDataCommandSignal>();
            Container.BindSignal<ShowDebugDataCommandSignal>()
                .ToMethod<ShowDebugDataCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Player Gameplay
            Container.Bind<ITickable>().To<ControlPlayerGameplayCommand>()
                .AsCached();
            
            Container.DeclareSignal<UpdateSpeedometerDataCommandSignal>();
            Container.BindSignal<UpdateSpeedometerDataCommandSignal>()
                .ToMethod<UpdateSpeedometerDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<UpdateDistancemeterDataCommandSignal>();
            Container.BindSignal<UpdateDistancemeterDataCommandSignal>()
                .ToMethod<UpdateDistancemeterDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<UpdatePointPositionCommandSignal>();
            Container.BindSignal<UpdatePointPositionCommandSignal>()
                .ToMethod<UpdatePointPositionCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
        }
    }
}