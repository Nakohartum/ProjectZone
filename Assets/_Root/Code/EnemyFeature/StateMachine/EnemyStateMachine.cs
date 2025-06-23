using System;
using System.Collections.Generic;
using _Root.Code.UpdateFeature;
using Game.Code.PlayerFeature;

namespace _Root.Code.EnemyFeature.StateMachine
{
    public class EnemyStateMachine : IUpdatable, IDisposable
    {
        private Dictionary<Type, IEnemyState> _states = new();
        private IEnemyState _currentState;
        public IPlayerView Player { get; set; }
        private EnemyAnimatorController _animatorController;

        public EnemyStateMachine(EnemyAnimatorController animatorController)
        {
            _animatorController = animatorController;
        }

        public void PlayIdleAnimation()
        {
            _animatorController.PlayIdleAnimation();
        }
        
        public void PlayWalkingAnimation()
        {
            _animatorController.PlayWalkingAnimation();
        }
        
        public void PlayAttackingAnimation()
        {
            _animatorController.PlayAttackingAnimation();
        }

        public void AddState(Type stateType, IEnemyState state)
        {
            _states.Add(stateType, state);
        }

        public void ChangeState(Type stateType)
        {
            if (_states.TryGetValue(stateType, out var state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter();
            }
        }

        public void Update(float deltaTime)
        {
            _currentState?.UpdateState(deltaTime);
        }

        public void Dispose()
        {
            UpdateController.Instance.RemoveUpdatable(this);
        }
    }
}