using _Root.Code.HealthFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public interface IPlayerModel
    {
        Vector3 Position { get; set; }
        float Speed { get; }
        float Acceleration { get; }
    }
}