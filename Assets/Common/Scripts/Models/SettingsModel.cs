using Common.Scripts.Json;
using Common.Scripts.Services;

namespace Common.Scripts.Models
{
    public class SettingsModel
    {
        public SettingsData SettingsData;
        public float MouseSensitivity;
        public int MouseVerticalInversion;
        public int BackwardMoveInversion;
        public readonly InputManager InputManager = new InputManager();
    }
}