using System;
using UnityEngine;
using Zenject;

namespace Common.Scripts.Installers
{
    public enum ShellType
    {
        Bb,
        Km,
        Of,
    }
    
    [CreateAssetMenu(fileName = "Shells Settings", menuName = "Common/Shells Settings")]
    public class ShellsSettings : ScriptableObjectInstaller<ShellsSettings>
    {
        public Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }

        [Serializable]
        public class Settings
        {
            public Shell Bb;
            public Shell Km;
            public Shell Of;
            
            [Serializable]
            public class Shell
            {
                public string Name;
                public Sprite Preview;
            }
        }
    }
}