using System;
using UnityEngine;
using Zenject;

namespace Common.Scripts.Installers
{
    [CreateAssetMenu(fileName = "TanksSettings", menuName = "Common/Tanks")]
    public class TanksSettings : ScriptableObjectInstaller<TanksSettings>
    {
        public Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }

        [Serializable]
        public class Settings
        {
            public TankSettings[] TanksList;
        }
    }
}