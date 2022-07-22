using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_1_Authorization.Scripts.Views;

namespace Scenes.Scene_1_Authorization.Scripts.Signals
{
    public class ChangeGameModeViewSignal : ISignal
    {
        public readonly bool IsPlayOnline;

        public ChangeGameModeViewSignal(bool isPlayOnline = true)
        {
            IsPlayOnline = isPlayOnline;
        }
    }

    #region Log In Panel
    public class LogInViewSignal : ISignal { }

    public class OpenRegistrationPanelViewSignal : ISignal { }
    
    public class OpenRestorePasswordPanelViewSignal : ISignal { }
    #endregion
    
    #region Restore Password Panel
    public class SendRestorePasswordRequestViewSignal : ISignal { }
    
    public class CancelRestorePasswordViewSignal : ISignal { }
    #endregion
    
    #region Registration Panel
    public class SendRegisterUserRequestViewSignal : ISignal { }
    
    public class CancelRegistrationViewSignal : ISignal { }
    #endregion

    #region Check Text Correctivity
    public class CheckEmailTextViewSignal : ISignal
    {
        public readonly string Text;

        public CheckEmailTextViewSignal(string text)
        {
            Text = text;
        }
    }
    
    public class CheckPasswordTextViewSignal : ISignal 
    { 
        public readonly string Text;

        public CheckPasswordTextViewSignal(string text)
        {
            Text = text;
        } 
    }

    public class CheckNicknameTextViewSignal : ISignal
    {
        public readonly string Text;

        public CheckNicknameTextViewSignal(string text)
        {
            Text = text;
        } 
    }

    public class EmailCheckingResultViewSignal : ISignal
    {
        public readonly string Warning;

        public EmailCheckingResultViewSignal(string warning = "")
        {
            Warning = warning;
        }
    }
    
    public class PasswordCheckingResultViewSignal : ISignal
    {
        public readonly string Warning;

        public PasswordCheckingResultViewSignal(string warning = "")
        {
            Warning = warning;
        }
    }
    
    public class NicknameCheckingResultViewSignal : ISignal
    {
        public readonly string Warning;

        public NicknameCheckingResultViewSignal(string warning = "")
        {
            Warning = warning;
        }
    }
    #endregion

    #region Additional Info
    public class AdditionalInfoButtonSelectedViewSignal : ISignal
    {
        public readonly AdditionalInfoButtonView View;

        public AdditionalInfoButtonSelectedViewSignal(AdditionalInfoButtonView view)
        {
            View = view;
        }
    }

    public class AdditionalInfoButtonDeselectedViewSignal : ISignal
    {
    } 
    #endregion
    
    public class LogInOfflineViewSignal : ISignal
    {
    }
}