using Scenes.Scene_0_Main.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Scenes.Scene_0_Main.Scripts.Views
{
    public abstract class ViewBase : MonoBehaviour, IView
    {
        protected SignalBus Signal;

        private void Awake()
        {
            InitUiComponentsOnAwake();
        }

        private void Start()
        {
            InitUiComponentsOnStart();
        }

        private void OnEnable()
        {
            SubscribeOnListeners();
        }

        private void OnDisable()
        {
            UnsubscribeFromListeners();
        }

        [Inject]
        public void Init(SignalBus signalBus)
        {
            Signal = signalBus;
        }

        protected virtual void InitUiComponentsOnAwake()
        {
        }

        protected virtual void InitUiComponentsOnStart()
        {
        }

        protected virtual void SubscribeOnListeners()
        {
        }

        protected virtual void UnsubscribeFromListeners()
        {
        }
    }
}