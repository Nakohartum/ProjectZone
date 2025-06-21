using _Root.Code.HealthFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    [CreateAssetMenu(fileName = nameof(PlayerScriptableObject), menuName = "Create/Player/"+nameof(PlayerScriptableObject), order = 0)]
    public class PlayerScriptableObject : ScriptableObject
    {
        [field: SerializeField] public PlayerView PlayerPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public HealthScriptableObject Health { get; private set; }
    }
}