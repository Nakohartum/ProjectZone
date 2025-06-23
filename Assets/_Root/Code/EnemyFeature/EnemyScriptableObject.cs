using _Root.Code.HealthFeature;
using _Root.Code.InventoryFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature
{
    [CreateAssetMenu(fileName = nameof(EnemyScriptableObject), menuName = "Create/Enemy/"+nameof(EnemyScriptableObject), order = 0)]
    public class EnemyScriptableObject : ScriptableObject
    {
        [field: SerializeField] public HealthScriptableObject Health { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public float RadiusOfAttack { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float AttackCooldown { get; private set; }
        [field: SerializeField] public EnemyView EnemyPrefab { get; private set; }
        [field: SerializeField] public InventoryItemScriptableObject InventoryItem { get; private set; }
    }
}