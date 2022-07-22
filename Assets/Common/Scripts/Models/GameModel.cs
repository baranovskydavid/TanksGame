using Scenes.Scene_2_Hangar.Scripts.Json;
using UnityEngine;

namespace Common.Scripts.Models
{
    public enum NetworkGameMode
    {
        Online,
        Offline,
    }

    public class GameModel
    {
        public NetworkGameMode NetworkGameMode;
        public PlayerData PlayerData;

        public bool HangarIsEmpty;
        public int SelectedTankId;
        public GameObject SelectedTank;

        public bool InMatch;
        public bool IsPaused;

        public Transform PanelsParent;
        public GameObject InstantiatedPanel;
    }
}