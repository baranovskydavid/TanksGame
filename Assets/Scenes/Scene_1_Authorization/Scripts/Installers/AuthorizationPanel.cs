using System;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_1_Authorization.Scripts.Installers
{
    [CreateAssetMenu(fileName = "AuthorizationPanel", menuName = "Scene_1_Authorization/AuthorizationPanel")]
    public class AuthorizationPanel : ScriptableObjectInstaller<AuthorizationPanel>
    {
        public Settings settings;
        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }

        [Serializable]
        public class Settings
        {
            public Sprite Background;

            [Header("Nicknames")]
            [Range(0,6)]  public int MinNicknameLength;
            public string NicknameSymbols;
            public string[] ProhibitedWords;
            public string NicknameSmall;
            public string NicknameUseProhibitedWords;
            public string NicknameUseProhibitedSymbols;

            [Header("Email")] 
            public string EmailIncorrect;
            
            [Header("Password")]
            [Range(0,16)] public int MinPasswordLength;
            public string PasswordSymbols;
            public string PasswordSmall;
            public string PasswordUseProhibitedSymbols;

            [Header("Additional Info Panel")] 
            public Vector3 AdditionalInfoPanelOffset;
        }
    }
}
