using Scenes.Scene_0_Main.Scripts.Interfaces;
using Scenes.Scene_3_Battlefield.Scripts.Views.Tank;
using UnityEngine;

namespace Scenes.Scene_3_Battlefield.Scripts.Commands.PlayerTank.Motor
{
    public class UpdateTrackTextureOffsetCommand : ICommandWithParameters
    {
        public void Execute(ISignal signal)
        {
            var parameter = (UpdateTrackTextureOffsetCommandSignal) signal;
            var view = parameter.TrackView;
            
            //Multiply 1,000 to convert kilometers to meters and divide by 3,600 to find the distance per second
            var distancePerFrame = parameter.AverageSpeed * 1000 / 3600 * Time.fixedDeltaTime;
            var trackOffsetPerFrame = distancePerFrame / view.TrackLength;
            view.SkinnedMeshRenderer.material.mainTextureOffset += view.TextureOffsetAxis * trackOffsetPerFrame;
        }
    }

    public class UpdateTrackTextureOffsetCommandSignal : ISignal
    {
        public readonly TrackView TrackView;
        public readonly float AverageSpeed;

        public UpdateTrackTextureOffsetCommandSignal(TrackView trackView, float averageSpeed)
        {
            TrackView = trackView;
            AverageSpeed = averageSpeed;
        }
    }
}