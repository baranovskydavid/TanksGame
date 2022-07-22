using Common.Scripts.Services;
using UnityEngine;

namespace Common.Scripts.Installers
{
    [CreateAssetMenu(fileName = "Input Manager Settings", menuName = "Common/Input Manager Settings")]
    public class InputManagerSettings : ScriptableObject
    {
        public InputManager.Axis[] Axes;
    }
}