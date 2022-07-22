using System;
using UnityEngine;

namespace Common.Scripts.Json
{
    public class SettingsData
    {
        public GraphicSettings graphicSettings = new GraphicSettings();
        public InputSettings inputSettings = new InputSettings();
        public SoundsSettings soundsSettings = new SoundsSettings();

        [Serializable]
        public class GraphicSettings
        {
            public int GraphicQualityLevel = 2;
            public int FrameRate;
            public int ResolutionValue = Screen.resolutions.Length - 1;
            public int FullScreenMode = 2;
        }

        [Serializable]
        public class InputSettings
        {
            public float MouseSensitivity = 100f;
            public bool MouseVerticalInversion = true;
            public bool BackwardMoveInversion = true;
        }

        [Serializable]
        public class SoundsSettings
        {
            public float SoundsVolume = 100f;
            public float MusicVolume = 100f;
            public float PostEffectsVolume = 100f;
        }
    }
}