using _Root.Code.EnemyFeature;
using _Root.Code.UpdateFeature;
using UnityEngine;

namespace _Root.Code.ShootingFeature.Aiming
{
    public class TargetGetter : IFixedUpdatable
    {
        private Rigidbody2D _root;
        public IEnemyView Target { get; private set; }
        public float _targetRadius;

        public TargetGetter(Rigidbody2D root)
        {
            _root = root;
            UpdateController.Instance.AddFixedUpdatable(this);
        }

        public void SetTargetRadius(float radius)
        {
            _targetRadius = radius;
        }
        
        private void GetTarget()
        {
            var overlapCircleAll = Physics2D.OverlapCircleAll(_root.position, _targetRadius);
            if (overlapCircleAll.Length > 0)
            {
                foreach (Collider2D collider2D in overlapCircleAll)
                {
                    if (collider2D.TryGetComponent(out IEnemyView enemyView))
                    {
                        Target = enemyView;
                        break;
                    }
                }
            }
        }

        public void FixedUpdate()
        {
            GetTarget();
        }
    }
}