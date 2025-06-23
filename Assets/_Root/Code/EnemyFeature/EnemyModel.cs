using _Root.Code.InventoryFeature;

namespace _Root.Code.EnemyFeature
{
    public class EnemyModel : IEnemyModel
    {
        public float Speed { get; private set; }
        public float Acceleration { get; private set; }
        public float RadiusOfAttack { get; private set; }
        public float Damage { get; private set; }
        public float AttackCooldown { get; private set; }
        public InventoryItemScriptableObject FallenItem { get; private set; }

        public EnemyModel(float speed, float acceleration, float radiusOfAttack, float damage, float attackCooldown, InventoryItemScriptableObject fallenItem)
        {
            Speed = speed;
            Acceleration = acceleration;
            RadiusOfAttack = radiusOfAttack;
            Damage = damage;
            AttackCooldown = attackCooldown;
            FallenItem = fallenItem;
        }
    }
}