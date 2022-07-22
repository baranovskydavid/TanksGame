using Common.Scripts.Views.SettingsPanel;
using Scenes.Scene_0_Main.Scripts.Interfaces;
using TMPro;

namespace Common.Scripts.Signals
{
    #region Settings View
        public class ChangeSettingsPanelContentViewSignal : ISignal
        {
            public readonly int Id;

            public ChangeSettingsPanelContentViewSignal(int id)
            {
                Id = id;
            }
        }

        public class ApplySettingsChangesViewSignal : ISignal
        {
        }
   
        public class ResetSettingsViewSignal : ISignal
        {
        }
    
        public class CloseSettingsPanelViewSignal : ISignal
        {
        }
    
        public class SetSliderValueToTextViewSignal : ISignal
        {
            public readonly float Value;
            public readonly TextMeshProUGUI Text;

            public SetSliderValueToTextViewSignal(float value, TextMeshProUGUI text)
            {
                Value = value;
                Text = text;
            }
        }

        public class SignOutViewSignal : ISignal
        {
        }

        public class ChangeInputKeyViewSignal : ISignal
        {
            public readonly InputKeyView View;

            public ChangeInputKeyViewSignal(InputKeyView view)
            {
                View = view;
            }
        }

        public class HideReplaceKeyWarningPanelViewSignal : ISignal
        {
            
        } 
        
        public class ReplaceInputKeyViewSignal : ISignal
        {
            public readonly string AxisName;
            public readonly bool IsPositiveKey;
            public readonly string MatchedAxisName;
            public readonly bool MatchedKeyIsPositive;

            public ReplaceInputKeyViewSignal(string axisName, bool isPositiveKey, string matchedAxisName, bool matchedKeyIsPositive)
            {
                AxisName = axisName;
                IsPositiveKey = isPositiveKey;
                MatchedAxisName = matchedAxisName;
                MatchedKeyIsPositive = matchedKeyIsPositive;
            }
        }

        #endregion
        
        #region Pause View

        public class ResumeGameViewSignal : ISignal
        {
        }
        
        public class OpenSettingsPanelViewSignal : ISignal
        {
        } 
        
        public class ExitToHangarViewSignal : ISignal
        {
        }
        
        public class ExitFromGameViewSignal : ISignal
        {
        }

        #endregion
}