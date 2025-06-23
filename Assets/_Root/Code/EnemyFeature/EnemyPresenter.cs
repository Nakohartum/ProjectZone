using System;
using _Root.Code.EnemyFeature.StateMachine;
using _Root.Code.HealthFeature;
using _Root.Code.MoveFeature;
using _Root.Code.UpdateFeature;
using Game.Code.PlayerFeature;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Root.Code.EnemyFeature
{
    public class EnemyPresenter : IDisposable
    {
        private IEnemyModel _enemyModel;
        private HealthPresenter _healthPresenter;
        private IEnemyView _enemyView;
        private IMoveable _moveable;
        private PlayerChecker _playerChecker;
        private EnemyStateMachine _enemyStateMachine;

        public EnemyPresenter(IEnemyModel enemyModel, HealthPresenter healthPresenter, IEnemyView enemyView, IMoveable moveable, PlayerChecker playerChecker, EnemyStateMachine enemyStateMachine)
        {
            _enemyModel = enemyModel;
            _healthPresenter = healthPresenter;
            _enemyView = enemyView;
            _moveable = moveable;
            _playerChecker = playerChecker;
            _enemyStateMachine = enemyStateMachine;
            _enemyView.Initialize(this);
            _enemyStateMachine.ChangeState(typeof(ChasingState));
            _healthPresenter.OnDeath.AddListener(Die);
        }

        private void Die()
        {
            Object.Instantiate(_enemyModel.FallenItem.ObjectToSpawn, _enemyView.GameObject.transform.position, Quaternion.identity);
            _enemyView.GameObject.SetActive(false);
        }

        public void GetDamage(float damage)
        {
            _healthPresenter.GetDamage(damage);
        }

        public void Dispose()
        {
            _healthPresenter.OnDeath.RemoveListener(Die);
            _playerChecker.Dispose();
            _enemyStateMachine.Dispose();
            
        }
    }
}