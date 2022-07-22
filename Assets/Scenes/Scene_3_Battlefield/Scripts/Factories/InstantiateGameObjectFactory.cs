using UnityEngine;
using Zenject;

namespace Scenes.Scene_3_Battlefield.Scripts.Factories
{
    public class InstantiateGameObjectFactory : IFactory<GameObject, GameObject>
    {
        private readonly DiContainer _container;

        public InstantiateGameObjectFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Create(GameObject prefab)
        {
            return _container.InstantiatePrefab(prefab);
        }

        public GameObject Create(GameObject prefab, Transform parent)
        {
            return _container.InstantiatePrefab(prefab, parent);
        }
    }
}