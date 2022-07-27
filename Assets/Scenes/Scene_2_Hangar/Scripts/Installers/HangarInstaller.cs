using Common.Scripts.Mediators;
using Scenes.Scene_2_Hangar.Scripts.Commands.MainInfoPanel;
using Scenes.Scene_2_Hangar.Scripts.Commands.PreviewCamera;
using Scenes.Scene_2_Hangar.Scripts.Commands.StartBattlePanel;
using Scenes.Scene_2_Hangar.Scripts.Commands.TanksListPanel;
using Scenes.Scene_2_Hangar.Scripts.Factories;
using Scenes.Scene_2_Hangar.Scripts.Mediators;
using Scenes.Scene_2_Hangar.Scripts.Signals;
using Zenject;

namespace Scenes.Scene_2_Hangar.Scripts.Installers
{
    public class HangarInstaller : MonoInstaller
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

        private void InstallServices() { }

        private void InstallViews()
        {
            Container.Bind<InstantiateGameObjectFactory>()
                .AsSingle();
        }
        
        private void InstallModels() { }

        private void InstallSignals() { }

        private void InstallViewSignals()
        {
            Container.DeclareSignal<ShowPlayerNameViewSignal>();
            Container.DeclareSignal<ShowBanknotesCountViewSignal>();
            Container.DeclareSignal<ShowFreeExperienceCountViewSignal>();
            
            Container.DeclareSignal<SelectPreviewTankViewSignal>();
            Container.DeclareSignal<PreviewTankChangedViewSignal>();

            Container.DeclareSignal<StartBattleViewSignal>();
        }

        private void InstallMediators()
        {
            Container.BindInterfacesAndSelfTo<ContentViewMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<PreviewCameraMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<MainInfoPanelMediator>()
                .AsSingle(); 
            Container.BindInterfacesAndSelfTo<TanksListPanelMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<StartBattlePanelMediator>()
                .AsSingle();
        }

        private void InstallCommandSignals()
        {
            #region Preview Camera
            Container.Bind<IFixedTickable>().To<ControlPreviewCameraCommand>()
                .AsCached();
            
            Container.DeclareSignal<RotatePreviewCameraCommandSignal>();
            Container.BindSignal<RotatePreviewCameraCommandSignal>()
                .ToMethod<RotatePreviewCameraCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<ZoomPreviewCameraCommandSignal>();
            Container.BindSignal<ZoomPreviewCameraCommandSignal>()
                .ToMethod<ZoomPreviewCameraCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<CheckPreviewCameraCollisionsCommandSignal>();
            Container.BindSignal<CheckPreviewCameraCollisionsCommandSignal>()
                .ToMethod<CheckPreviewCameraCollisionsCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<SetPreviewCameraPositionCommandSignal>();
            Container.BindSignal<SetPreviewCameraPositionCommandSignal>()
                .ToMethod<SetPreviewCameraPositionCommand>(signal => signal.Execute)
                .FromNew(); 
            #endregion
            
            #region Main Info Panel
            Container.DeclareSignal<ShowPlayerNameCommandSignal>();
            Container.BindSignal<ShowPlayerNameCommandSignal>()
                .ToMethod<ShowPlayerNameCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<ShowBanknotesCountCommandSignal>();
            Container.BindSignal<ShowBanknotesCountCommandSignal>()
                .ToMethod<ShowBanknotesCountCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ShowFreeExperienceCountCommandSignal>();
            Container.BindSignal<ShowFreeExperienceCountCommandSignal>()
                .ToMethod<ShowFreeExperienceCountCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Tanks List Panel
            Container.DeclareSignal<InstantiateTanksButtonsCommandSignal>();
            Container.BindSignal<InstantiateTanksButtonsCommandSignal>()
                .ToMethod<InstantiateTanksButtonsCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SelectPreviewTankCommandSignal>();
            Container.BindSignal<SelectPreviewTankCommandSignal>()
                .ToMethod<SelectTankCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<InstantiatePreviewTankCommandSignal>();
            Container.BindSignal<InstantiatePreviewTankCommandSignal>()
                .ToMethod<InstantiatePreviewTankCommand>(signal => signal.Execute)
                .FromNew();
            #endregion

            #region Start Battle Panel
            Container.DeclareSignal<StartBattleCommandSignal>();
            Container.BindSignal<StartBattleCommandSignal>()
                .ToMethod<StartBattleCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
        }
    }
}