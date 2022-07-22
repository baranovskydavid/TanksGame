using Scenes.Scene_0_Main.Scripts.Views;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Views.Tank
{
    public class TrackView : ViewBase
    { 
        public SkinnedMeshRenderer SkinnedMeshRenderer;
        
        [Header("Settings")] 
        public Vector2 TextureOffsetAxis;
        public float TrackLength;
    }
}