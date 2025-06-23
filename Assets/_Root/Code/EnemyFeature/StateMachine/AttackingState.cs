using Game.Code.PlayerFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature.StateMachine
{
    public class AttackingState : IEnemyState
    {
        private float _damage;
        private float _attackingRadius;
        private EnemyStateMachine _enemyStateMachine;
        private Transform _transform;
        private float _attackCooldown;
        private float _cooldownTimer;

        public AttackingState(float damage,float attackingRadius, EnemyStateMachine enemyStateMachine, Transform transform, float attackCooldown)
        {
            _damage = damage;
            _attackingRadius = attackingRadius;
            _enemyStateMachine = enemyStateMachine;
            _transform = transform;
            _attackCooldown = attackCooldown;
        }
        
        public void Enter()
        {
            _enemyStateMachine.Player.PlayerPresenter.GetDamage(_damage);
        }

        public void Exit()
        {
            
        }

        public void UpdateState(float deltaTime)
        {
            if (_cooldownTimer > 0)
            {
                _cooldownTimer -= deltaTime;
                return;
            }
            if (Vector3.Distance(_enemyStateMachine.Player.GameObject.transform.position, _transform.position) > _attackingRadius)
            {
                _enemyStateMachine.ChangeState(typeof(ChasingState));
            }
            else
            {
                _enemyStateMachine.PlayAttackingAnimation();
                _enemyStateMachine.Player.PlayerPresenter.GetDamage(_damage);
                _cooldownTimer = _attackCooldown;
            }
        }
    }
}