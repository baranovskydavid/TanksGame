using Scenes.Scene_0_Main.Scripts.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Scripts.Views.SettingsPanel
{
    public class InputSettingsView : ViewBase
    {
        public Slider Slider_MouseSensitivity;
        public TMP_Dropdown Dropdown_MouseVerticalInversion;
        public TMP_Dropdown Dropdown_BackwardMoveInversion;
        public InputKeyView[] InputKeysViews;

        [Header("Additional")] 
        public GameObject Blocker;
        public GameObject ListenForKey;
        public ReplaceKeyWarningView ReplaceKeyWarningView;
    }
}