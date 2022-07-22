using Common.Scripts.Mediators;
using Scenes.Scene_1_Authorization.Scripts.Commands;
using Scenes.Scene_1_Authorization.Scripts.Commands.Additional_Info_Panel;
using Scenes.Scene_1_Authorization.Scripts.Commands.Check_Text_Correctivity;
using Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Offline;
using Scenes.Scene_1_Authorization.Scripts.Commands.Log_In_Panel;
using Scenes.Scene_1_Authorization.Scripts.Commands.Registration_Panel;
using Scenes.Scene_1_Authorization.Scripts.Commands.Restore_Password_Panel;
using Scenes.Scene_1_Authorization.Scripts.Mediators;
using Scenes.Scene_1_Authorization.Scripts.Signals;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Installers
{
    public class AuthorizationInstaller : MonoInstaller
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
        }

        private void InstallSignals()
        {
        }

        private void InstallViewSignals()
        {
            Container.DeclareSignal<ChangeGameModeViewSignal>();
            
            Container.DeclareSignal<LogInViewSignal>();
            Container.DeclareSignal<OpenRegistrationPanelViewSignal>();
            Container.DeclareSignal<OpenRestorePasswordPanelViewSignal>();
            
            Container.DeclareSignal<SendRestorePasswordRequestViewSignal>();
            Container.DeclareSignal<CancelRestorePasswordViewSignal>();
            
            Container.DeclareSignal<SendRegisterUserRequestViewSignal>();
            Container.DeclareSignal<CancelRegistrationViewSignal>();
            
            Container.DeclareSignal<CheckEmailTextViewSignal>();
            Container.DeclareSignal<CheckPasswordTextViewSignal>();
            Container.DeclareSignal<CheckNicknameTextViewSignal>();
            Container.DeclareSignal<EmailCheckingResultViewSignal>();
            Container.DeclareSignal<PasswordCheckingResultViewSignal>();
            Container.DeclareSignal<NicknameCheckingResultViewSignal>();
            
            Container.DeclareSignal<AdditionalInfoButtonSelectedViewSignal>();
            Container.DeclareSignal<AdditionalInfoButtonDeselectedViewSignal>();
            
            Container.DeclareSignal<LogInOfflineViewSignal>();
        }

        private void InstallMediators()
        {
            Container.BindInterfacesAndSelfTo<AuthorizationPanelMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<ContentViewMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<GameModesMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<LogInPanelMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<RestorePasswordPanelMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<RegistrationPanelMediator>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<LogInOfflinePanelMediator>()
                .AsSingle();
        }

        private void InstallCommandSignals()
        {
            Container.DeclareSignal<SetAuthorizationPanelDataCommandSignal>();
            Container.BindSignal<SetAuthorizationPanelDataCommandSignal>()
                .ToMethod<SetAuthorizationPanelDataCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<ChangeGameModeCommandSignal>();
            Container.BindSignal<ChangeGameModeCommandSignal>()
                .ToMethod<ChangeGameModeCommand>(signal => signal.Execute)
                .FromNew();

            #region Log In Panel
            Container.DeclareSignal<LogInCommandSignal>();
            Container.BindSignal<LogInCommandSignal>()
                .ToMethod<LogInCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<OpenRegistrationPanelCommandSignal>();
            Container.BindSignal<OpenRegistrationPanelCommandSignal>()
                .ToMethod<OpenRegistrationPanelCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<OpenRestorePasswordPanelCommandSignal>();
            Container.BindSignal<OpenRestorePasswordPanelCommandSignal>()
                .ToMethod<OpenRestorePasswordPanelCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Restore Password Panel
            Container.DeclareSignal<SendRestorePasswordRequestCommandSignal>();
            Container.BindSignal<SendRestorePasswordRequestCommandSignal>()
                .ToMethod<SendRestorePasswordRequestCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<CancelRestorePasswordCommandSignal>();
            Container.BindSignal<CancelRestorePasswordCommandSignal>()
                .ToMethod<CancelRestorePasswordCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Registration
            Container.DeclareSignal<SendRegisterUserRequestCommandSignal>();
            Container.BindSignal<SendRegisterUserRequestCommandSignal>()
                .ToMethod<SendRegisterUserRequestCommand>(signal => signal.Execute)
                .FromNew();

            Container.DeclareSignal<CancelRegistrationCommandSignal>();
            Container.BindSignal<CancelRegistrationCommandSignal>()
                .ToMethod<CancelRegistrationCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Check Text Correctivity
            Container.DeclareSignal<CheckEmailTextCommandSignal>();
            Container.BindSignal<CheckEmailTextCommandSignal>()
                .ToMethod<CheckEmailTextCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<CheckPasswordTextCommandSignal>();
            Container.BindSignal<CheckPasswordTextCommandSignal>()
                .ToMethod<CheckPasswordTextCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<CheckNicknameTextCommandSignal>();
            Container.BindSignal<CheckNicknameTextCommandSignal>()
                .ToMethod<CheckNicknameTextCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Additional Info Panel
            Container.DeclareSignal<ShowAdditionalInfoPanelCommandSignal>();
            Container.BindSignal<ShowAdditionalInfoPanelCommandSignal>()
                .ToMethod<ShowAdditionalInfoPanelCommand>(signal => signal.Execute)
                .FromNew();
            
            Container.DeclareSignal<HideAdditionalInfoPanelCommandSignal>();
            Container.BindSignal<HideAdditionalInfoPanelCommandSignal>()
                .ToMethod<HideAdditionalInfoPanelCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
            
            #region Log In Offline
            Container.DeclareSignal<LogInOfflineCommandSignal>();
            Container.BindSignal<LogInOfflineCommandSignal>()
                .ToMethod<LogInOfflineCommand>(signal => signal.Execute)
                .FromNew(); 
            
            Container.DeclareSignal<CreateDefaultPlayerDataCommandSignal>();
            Container.BindSignal<CreateDefaultPlayerDataCommandSignal>()
                .ToMethod<CreateOfflinePlayerDataCommand>(signal => signal.Execute)
                .FromNew();
            #endregion
        }
    }
}