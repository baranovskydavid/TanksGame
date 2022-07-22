using Common.Scripts.Commands;
using Common.Scripts.Commands.PausePanel;
using Common.Scripts.Commands.PlayerData;
using Common.Scripts.Commands.SettingsData;
using Common.Scripts.Commands.SettingsPanel;
using Common.Scripts.Mediators;
using Common.Scripts.Models;
using Common.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Mediators;
using Scenes.Scene_0_Main.Scripts.Models;
using Scenes.Scene_0_Main.Scripts.Signals;
using Zenject;

namespace Common.Scripts.Installers
{
    public class CommonInstaller : MonoInstaller
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
        }

        private void InstallModels()
        {
            Container.Bind<GameModel>()
                .AsSingle();
            Container.Bind<SettingsModel>()
                .AsSingle();
        }

        private void InstallSignals()
        {
            #region Version Text View
            Container.DeclareSignal<SetVersionTextViewSignal>();
            #endregion

            #region Pause Panel
            Container.DeclareSignal<ResumeGameViewSignal>();
            Container.DeclareSignal<OpenSettingsPanelViewSignal>();
            Container.DeclareSignal<ExitToHangarViewSignal>();
            Container.DeclareSignal<ExitFromGameViewSignal>();
            #endregion

            #region Settings Panel & Data
            Container.DeclareSignal<ChangeSettingsPanelContentViewSignal>();
            Container.DeclareSignal<CloseSettingsPanelViewSignal>();

            Container.DeclareSignal<ApplySettingsChangesViewSignal>();
            Container.DeclareSignal<ResetSettingsViewSignal>();
            Container.DeclareSignal<SetSliderValueToTextViewSignal>();
            Container.DeclareSignal<SignOutViewSignal>();
            
            Container.DeclareSignal<ChangeInputKeyViewSignal>();
            Container.DeclareSignal<ReplaceInputKeyViewSignal>();
            Container.DeclareSignal<HideReplaceKeyWarningPanelViewSignal>();
            #endregion
        }

        private void InstallViewSignals()
        {
        }

        private void InstallMediators()
        {
            Container.BindInterfacesAndSelfTo<VersionTextMediator>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<PausePanelMediator>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<SettingsPanelMediator>()
                .AsSingle();
        }

        private void InstallCommandSignals()
        {
            Container.DeclareSignal<EscapeKeyClickedCommandSignal>();
            Container.BindSignal<EscapeKeyClickedCommandSignal>()
                .ToMethod<DestroyInstantiatedPanelOrOpenPauseMenuCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ChangeCursorStateCommandSignal>();
            Container.BindSignal<ChangeCursorStateCommandSignal>()
                .ToMethod<ChangeCursorStateCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<DestroyInstantiatedPanelCommandSignal>();
            Container.BindSignal<DestroyInstantiatedPanelCommandSignal>()
                .ToMethod<DestroyInstantiatedPanelCommand>(signal => signal.Execute)
                .FromNew();

            #region Pause Panel
            Container.DeclareSignal<InstantiatePausePanelCommandSignal>();
            Container.BindSignal<InstantiatePausePanelCommandSignal>()
                .ToMethod<InstantiatePausePanelCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<SetupPausePanelCommandSignal>();
            Container.BindSignal<SetupPausePanelCommandSignal>()
                .ToMethod<SetupPausePanelCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ExitToHangarCommandSignal>();
            Container.BindSignal<ExitToHangarCommandSignal>()
                .ToMethod<ExitToHangarCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ExitFromGameCommandSignal>();
            Container.BindSignal<ExitFromGameCommandSignal>()
                .ToMethod<ExitFromGameCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Settings Data
            Container.DeclareSignal<CreateDefaultSettingsDataCommandSignal>();
            Container.BindSignal<CreateDefaultSettingsDataCommandSignal>()
                .ToMethod<CreateDefaultSettingsDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<LoadSettingsDataCommandSignal>();
            Container.BindSignal<LoadSettingsDataCommandSignal>()
                .ToMethod<LoadSettingsDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SaveSettingsDataCommandSignal>();
            Container.BindSignal<SaveSettingsDataCommandSignal>()
                .ToMethod<SaveSettingsDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SetupGraphicSettingsCommandSignal>();
            Container.BindSignal<SetupGraphicSettingsCommandSignal>()
                .ToMethod<SetupGraphicSettingsCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Settings Panel
            Container.DeclareSignal<InstantiateSettingsPanelCommandSignal>();
            Container.BindSignal<InstantiateSettingsPanelCommandSignal>()
                .ToMethod<InstantiateSettingsPanelCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<ChangeSettingsPanelContentCommandSignal>();
            Container.BindSignal<ChangeSettingsPanelContentCommandSignal>()
                .ToMethod<ChangeSettingsPanelContentCommand>(signal => signal.Execute)
                .FromNew();
            
            #region General
            Container.DeclareSignal<ShowGeneralSettingsCommandSignal>();
            Container.BindSignal<ShowGeneralSettingsCommandSignal>()
                .ToMethod<ShowGeneralSettingsCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SignOutCommandSignal>();
            Container.BindSignal<SignOutCommandSignal>()
                .ToMethod<SignOutCommand>(signal => signal.Execute)
                .FromNew();
            #endregion

            #region Graphic
            Container.DeclareSignal<ShowGraphicSettingsCommandSignal>();
            Container.BindSignal<ShowGraphicSettingsCommandSignal>()
                .ToMethod<ShowGraphicSettingsCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ChangeGraphicSettingsCommandSignal>();
            Container.BindSignal<ChangeGraphicSettingsCommandSignal>()
                .ToMethod<ChangeGraphicSettingsCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SetupGraphicSettingsCommandSignal>();
            Container.BindSignal<SetupGraphicSettingsCommandSignal>()
                .ToMethod<SetupGraphicSettingsCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Input
            Container.DeclareSignal<ShowInputSettingsCommandSignal>();
            Container.BindSignal<ShowInputSettingsCommandSignal>()
                .ToMethod<ShowInputSettingsCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<ChangeInputSettingsCommandSignal>();
            Container.BindSignal<ChangeInputSettingsCommandSignal>()
                .ToMethod<ChangeInputSettingsCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SetupInputSettingsCommandSignal>();
            Container.BindSignal<SetupInputSettingsCommandSignal>()
                .ToMethod<SetupInputSettingsCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ChangeInputKeyCommandSignal>();
            Container.BindSignal<ChangeInputKeyCommandSignal>()
                .ToMethod<ChangeInputKeyCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ChangeListenForKeyTextStateCommandSignal>();
            Container.BindSignal<ChangeListenForKeyTextStateCommandSignal>()
                .ToMethod<ChangeListenForKeyTextStateCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ShowReplaceKeyWarningCommandSignal>();
            Container.BindSignal<ShowReplaceKeyWarningCommandSignal>()
                .ToMethod<ShowReplaceKeyWarningCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<HideReplaceKeyWarningCommandSignal>();
            Container.BindSignal<HideReplaceKeyWarningCommandSignal>()
                .ToMethod<HideReplaceKeyWarningCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ReplaceInputKeyCommandSignal>();
            Container.BindSignal<ReplaceInputKeyCommandSignal>()
                .ToMethod<ReplaceInputKeyCommand>(signal => signal.Execute)
                .FromNew();
            #endregion

            #region Sounds
            Container.DeclareSignal<ShowSoundsSettingsCommandSignal>();
            Container.BindSignal<ShowSoundsSettingsCommandSignal>()
                .ToMethod<ShowSoundsSettingsCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<ChangeSoundsSettingsCommandSignal>();
            Container.BindSignal<ChangeSoundsSettingsCommandSignal>()
                .ToMethod<ChangeSoundsSettingsCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            #endregion
            
            #region Player Data
            Container.DeclareSignal<LoadOfflinePlayerDataCommandSignal>();
            Container.BindSignal<LoadOfflinePlayerDataCommandSignal>()
                .ToMethod<LoadOfflinePlayerDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<SaveOfflinePlayerDataCommandSignal>();
            Container.BindSignal<SaveOfflinePlayerDataCommandSignal>()
                .ToMethod<SaveOfflinePlayerDataCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
        }
    }
}