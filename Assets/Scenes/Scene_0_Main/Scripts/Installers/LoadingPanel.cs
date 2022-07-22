using System;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_0_Main.Scripts.Installers
{
    [CreateAssetMenu(fileName = "LoadingPanel", menuName = "Scene_0_Main/LoadingPanel")]
    public class LoadingPanel : ScriptableObjectInstaller<LoadingPanel>
    {
        public Settings settings;
        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }

        [Serializable]
        public class Settings
        {
            public GameObject Prefab;
            public Sprite Background;
            public string Description;
            public int MillisecondsDelayAfterLoading;
        }
    }
}
