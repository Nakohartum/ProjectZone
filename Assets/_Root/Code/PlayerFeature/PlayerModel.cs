using _Root.Code.SaveFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerModel : IPlayerModel
    {
        public Vector3 Position { get; set; }
        public float Speed { get; private set; }
        public float Acceleration { get; private set; }

        public PlayerModel(Vector3 position, float speed, float acceleration)
        {
            Position = position;
            Speed = speed;
            Acceleration = acceleration;
        }
        

        public struct SaveData
        {
            public Vector3 Position;
            public float Health;
        }
    }
}