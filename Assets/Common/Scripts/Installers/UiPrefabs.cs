using System;
using UnityEngine;
using Zenject;

namespace Common.Scripts.Installers
{
    [CreateAssetMenu(fileName = "UiPrefabs", menuName = "Common/UiPrefabs")]
    public class UiPrefabs : ScriptableObjectInstaller<UiPrefabs>
    {
        public Prefabs prefabs;

        public override void InstallBindings()
        {
            Container.BindInstance(prefabs);
        }

        [Serializable]
        public class Prefabs
        {
            public GameObject PausePanel;
            public GameObject SettingsPanel;
        }
    }
}