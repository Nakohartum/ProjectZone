using _Root.Code.MoveFeature;
using Game.Code.PlayerFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature.StateMachine
{
    public class ChasingState : IEnemyState
    {
        private PlayerChecker _playerChecker;
        private EnemyStateMachine _enemyStateMachine;
        private IEnemyModel _enemyModel;
        private IEnemyView _enemyView;
        private IMoveable _moveable;
        private EnemyAnimatorController _enemyAnimatorController;

        public ChasingState(PlayerChecker playerChecker, EnemyStateMachine enemyStateMachine, IEnemyModel enemyModel, IEnemyView enemyView, IMoveable moveable)
        {
            _playerChecker = playerChecker;
            _enemyStateMachine = enemyStateMachine;
            _enemyModel = enemyModel;
            _enemyView = enemyView;
            _moveable = moveable;
        }
        
        public void Enter()
        {
            _enemyStateMachine.Player = null;
            _playerChecker.OnPlayerSeen.AddListener(OnPlayerSeen);
        }

        private void OnPlayerSeen(IPlayerView playerView)
        {
            _enemyStateMachine.Player = playerView;
            Vector3 dir = playerView.GameObject.transform.position - _enemyView.GameObject.transform.position;
            float dist = dir.magnitude;
            if (dist > _enemyModel.RadiusOfAttack)
            {
                dir = dir / (dist + 1);
                dir = playerView.GameObject.transform.position - dir * _enemyModel.RadiusOfAttack;
                _moveable.Move(dir);
                
            }
            else
            {
                _enemyStateMachine.ChangeState(typeof(AttackingState));
            }
            
            
        }

        public void Exit()
        {
            _playerChecker.OnPlayerSeen.RemoveListener(OnPlayerSeen);
        }

        public void UpdateState(float deltaTime)
        {
            if (_moveable.IsMoving)
            {
                _enemyStateMachine.PlayWalkingAnimation();
            }
            else
            {
                _enemyStateMachine.PlayIdleAnimation();
            }
        }
    }
}