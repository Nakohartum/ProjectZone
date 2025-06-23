using _Root.Code.HealthFeature;
using _Root.Code.InventoryFeature;

namespace _Root.Code.EnemyFeature
{
    public interface IEnemyModel
    {
        float Speed { get; }
        float Acceleration { get; }
        float RadiusOfAttack { get; }
        float Damage { get; }
        float AttackCooldown { get; }
        InventoryItemScriptableObject FallenItem { get; }
        
    }
}