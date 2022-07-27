using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Scene_2_Hangar.Scripts.Json
{
    public class PlayerData
    {
        public string PlayerName = "Player";
        public int BanknotesCount = 0;
        public int FreeExperienceCount = 0;

        public List<Tank> Tanks = new List<Tank>();

        public string AccountBirthday = DateTime.Now.ToString();
    }

    [Serializable]
    public class Tank
    {
        public enum TankStatus
        {
            Default,
            Invented,
            Bought,
        }
        
        public TankStatus tankStatus = TankStatus.Default;
    }
}
