using Scenes.Scene_0_Main.Scripts.Constants;
using UnityEngine.SceneManagement;

namespace Scenes.Scene_0_Main.Scripts.Services
{
    public class SceneService
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        public void ReloadScene(string sceneName)
        {
            UnloadUnusedScene();
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        public void SceneLoaded(string sceneName)
        {
            UnloadUnusedScene();
            ShowSceneContent(sceneName);
        }

        private void ShowSceneContent(string sceneName)
        {
            for (var count = 0; count < SceneManager.sceneCount; count++)
            {
                var scene = SceneManager.GetSceneAt(count);
                if (scene.name.Equals(sceneName) && scene.isLoaded)
                {
                    ShowContent(scene, true);
                    SceneManager.SetActiveScene(scene);
                    break;
                }
            }
        }

        private void UnloadUnusedScene()
        {
            var scene = SceneManager.GetActiveScene();
            if (!scene.name.Equals(MainConstants.ScenesNames.Main))
            {
                ShowContent(scene, false);
                SceneManager.UnloadSceneAsync(scene);
            }
        }

        private void ShowContent(Scene scene, bool status)
        {
            var sceneObjects = scene.GetRootGameObjects();

            foreach (var go in sceneObjects)
            {
                var sceneComponent = go.GetComponent<ContentController>();
                if (sceneComponent != null) sceneComponent.ShowContent(status);
            }
        }
    }
}