using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public interface IPlayerFactory
    {
        IPlayerView CreatePlayer(Vector3 position);
    }
}