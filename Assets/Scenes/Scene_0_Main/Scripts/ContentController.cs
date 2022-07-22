using System.Linq;
using Scenes.Scene_0_Main.Scripts.Signals;
using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_0_Main.Scripts
{
    public class ContentController : ViewBase
    {
        private GameObject _sceneContentRoot;

        private void Start()
        {
            SetupContentRoot();
            NotifySceneLoaded();
        }

        private void SetupContentRoot()
        {
            _sceneContentRoot = gameObject.scene.GetRootGameObjects().First(go => !go.GetComponent<ContentController>());
        }

        private void NotifySceneLoaded()
        {
            Signal.Fire(new SceneLoadedCommandSignal(gameObject.scene.name));
        }

        public void ShowContent(bool status)
        {
            _sceneContentRoot.SetActive(status);
        }
    }
}