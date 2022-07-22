using System;
using System.IO;
using System.Linq;
using Common.Scripts.Installers;
using Cysharp.Threading.Tasks;
using ModestTree;
using Scenes.Scene_0_Main.Scripts.Constants;
using UnityEngine;

namespace Common.Scripts.Services
{
    public class InputManager
    {
        [Serializable]
        public class Axis
        {
            public string Name;
            public KeyCode PositiveKey;
            public KeyCode NegativeKey;
        }

        private class InputData
        {
            public Axis[] Axes;
        }

        private InputManagerSettings _settings;
        private Axis[] Axes;

        public InputManager()
        {
            _settings = Resources.Load<InputManagerSettings>(MainConstants.ResourcesPaths.InputManagerSettingsFile);
        }

        #region Axis
        public int GetAxisValue(string axisName)
        {
            var axis = Axes.FirstOrDefault(ax => ax.Name.Equals(axisName));

            if (axis == null)
            {
                Debug.LogError($"Axis with title {axisName} don't exist.");
                return 0;
            }
            
            var value = 0;
            if (Input.GetKey(axis.PositiveKey))
            {
                value++;
            }
            if (Input.GetKey(axis.NegativeKey))
            {
                value--;
            }

            return value;
        }

        public KeyCode GetAxisKeyCode(string axisName, bool isPositiveKey)
        {
            var axis = Axes.FirstOrDefault(ax => ax.Name.Equals(axisName));

            if (axis == null)
            {
                Debug.LogError($"Axis with title {axisName} don't exist.");
                return 0;
            }

            return isPositiveKey ? axis.PositiveKey : axis.NegativeKey;
        }
        
        public void ReplaceAxesKeyCodes(Action onComplete, string axisName, bool isPositiveKey, string matchedAxisName, bool matchedKeyIsPositive)
        {
            SetAxisKeyCode(axisName, isPositiveKey, GetAxisKeyCode(matchedAxisName, matchedKeyIsPositive));
            SetAxisKeyCode(matchedAxisName, matchedKeyIsPositive, KeyCode.None);
            onComplete?.Invoke();
        }
        
        private Axis GetAxis(string axisName)
        {
            var axis = (Axes.Where(ax => ax.Name.Equals(axisName))).FirstOrDefault();

            if (axis == null)
            {
                Debug.LogError($"Axis with title {axisName} don't exist.");
                return null;
            }

            return axis;
        }

        
        private void SetAxisKeyCode(string axisName, bool isPositiveKey, KeyCode keyCode)
        {
            var axis = GetAxis(axisName);
            
            var index = Axes.IndexOf(axis);

            if (isPositiveKey)
            {
                axis.PositiveKey = keyCode;
            }
            else
            {
                axis.NegativeKey = keyCode;
            }

            Axes.SetValue(axis, index);
        }
        #endregion
        
        #region Rebinding 
        public void RebindKey(Action onComplete, Action<string, bool> onMatch, Action onCancelled, string axisName, bool isPositiveKey)
        {
            ListenForKey(keyCode =>
            {
                if (keyCode == KeyCode.Escape)
                {
                    onCancelled?.Invoke();
                    return;
                }

                foreach (var axis in Axes)
                {
                    if (axis.PositiveKey == keyCode)
                    {
                        onMatch?.Invoke(axis.Name, true);   
                        return;
                    }
                    if(axis.NegativeKey == keyCode)
                    {
                        onMatch?.Invoke(axis.Name, false);
                        return;
                    }
                }
                
                SetAxisKeyCode(axisName, isPositiveKey, keyCode);
                onComplete?.Invoke();
            });
        }

        private async void ListenForKey(Action<KeyCode> callback)
        {
            var keyCodes = Enum.GetValues(typeof(KeyCode));

            while (true)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        callback?.Invoke(KeyCode.Escape);
                    }

                    foreach (var keyCode in keyCodes)
                    {
                        if (Input.GetKeyDown((KeyCode) keyCode))
                        { 
                            callback?.Invoke((KeyCode) keyCode);
                            return;
                        }
                    }
                }
                await UniTask.Yield();
            }
        }
        #endregion
        
        #region Saves
        public void LoadInputData()
        {
            var path = Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder + MainConstants.JsonPaths.InputDataFile;
            if (!File.Exists(path))
            {
                CreateDefaultInputDataSaves();
                return;
            }

            var json =   File.ReadAllText(path);
            var inputData = JsonUtility.FromJson<InputData>(json);
            Axes = inputData.Axes;
        }

        public void SaveInputData()
        {
            var inputData = new InputData {Axes = Axes};
            var json = JsonUtility.ToJson(inputData);
            File.WriteAllText(Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder + MainConstants.JsonPaths.InputDataFile, json);
        }

        public void CreateDefaultInputDataSaves()
        {
            var inputData = new InputData {Axes = _settings.Axes};
            var json = JsonUtility.ToJson(inputData);
            File.WriteAllText(Application.persistentDataPath + MainConstants.JsonPaths.OfflineFolder + MainConstants.JsonPaths.InputDataFile, json);
        }
        #endregion
    }
}
