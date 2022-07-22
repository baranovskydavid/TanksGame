using Common.Scripts.Commands;
using Common.Scripts.Commands.SettingsData;
using Scenes.Scene_0_Main.Scripts.Commands.LoadingPanels;
using Scenes.Scene_0_Main.Scripts.Commands.SceneService;
using Scenes.Scene_0_Main.Scripts.Factories;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Services;
using Scenes.Scene_0_Main.Scripts.Signals;
using Zenject;

namespace Scenes.Scene_0_Main.Scripts.Installers
{
    public class MainInstaller : MonoInstaller
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
            Container.Bind<SceneService>().AsSingle();
        }

        private void InstallViews()
        {
            Container.Bind<InstantiateGameObjectFactory>()
                .AsSingle();
        }

        private void InstallModels()
        {
            Container.Bind<MainModel>()
                .AsSingle();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<OnViewEnableViewSignal>();
            Container.DeclareSignal<OnViewDisableViewSignal>();
            
            Container.DeclareSignal<StartLoadingSceneViewSignal>();
            Container.DeclareSignal<SceneLoadingCompletedViewSignal>();
        }

        private void InstallViewSignals()
        {
        }

        private void InstallMediators()
        {
        }

        private void InstallCommandSignals()
        {
            Container.DeclareSignal<OnApplicationLoadedCommandSignal>();
            Container.BindSignal<OnApplicationLoadedCommandSignal>()
                .ToMethod<LoadStartupSceneCommand>(signal => signal.Execute)
                .FromNew();
            Container.BindSignal<OnApplicationLoadedCommandSignal>()
                .ToMethod<SetupSettingsCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<LoadSceneCommandSignal>();
            Container.BindSignal<LoadSceneCommandSignal>()
                .ToMethod<LoadSceneCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<ReloadSceneCommandSignal>();
            Container.BindSignal<ReloadSceneCommandSignal>()
                .ToMethod<ReloadSceneCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<SceneLoadedCommandSignal>();
            Container.BindSignal<SceneLoadedCommandSignal>()
                .ToMethod<ShowLoadedSceneCommand>(signal => signal.Execute)
                .FromNew();
            Container.BindSignal<SceneLoadedCommandSignal>()
                .ToMethod<DestroyLoadingPanelCommand>(signal => signal.Execute)
                .FromNew();
            Container.BindSignal<SceneLoadedCommandSignal>()
                .ToMethod<BindEscapeKeyCommand>(signal => signal.Execute)
                .FromNew();
                
            #region Loading Panel
            Container.DeclareSignal<InstantiateLoadingPanelCommandSignal>();
            Container.BindSignal<InstantiateLoadingPanelCommandSignal>()
                .ToMethod<InstantiateLoadingPanelCommand>(signal => signal.Execute)
                .FromNew();
            Container.BindSignal<InstantiateLoadingPanelCommandSignal>()
                .ToMethod<SetLoadingPanelDataCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
        }
    }
}