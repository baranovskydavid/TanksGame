using System;
using UnityEngine;
using Zenject;

namespace Common.Scripts.Installers
{
    [CreateAssetMenu(fileName = "SettingsPanelSettings", menuName = "Scene_0_Main/SettingsPanelSettings")]
    public class SettingsPanelSettings : ScriptableObjectInstaller<SettingsPanelSettings>
    {
        public Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }

        [Serializable]
        public class Settings
        {
            public Color SelectedButtonColor;
            public Color DeselectedButtonColor;
        }
    }
}