using System;
using _Root.Code.UpdateFeature;
using Game.Code.PlayerFeature;
using UnityEngine;
using UnityEngine.Events;

namespace _Root.Code.EnemyFeature
{
    public class PlayerChecker : IUpdatable, IDisposable
    {
        private float _cooldown = 1.5f;
        private float _currentTime = 0f;
        private Transform _transform;
        public UnityEvent<IPlayerView> OnPlayerSeen = new UnityEvent<IPlayerView>();

        public PlayerChecker(Transform transform)
        {
            _transform = transform;
        }
        
        public void Update(float deltaTime)
        {
            if (_currentTime <= _cooldown)
            {
                _currentTime += deltaTime;
                return;
            }
            var overlapCircleAll = Physics2D.OverlapCircleAll(_transform.position, 10f);
            if (overlapCircleAll.Length > 0)
            {
                foreach (var collider2D in overlapCircleAll)
                {
                    if (collider2D.TryGetComponent(out IPlayerView playerView))
                    {
                        OnPlayerSeen.Invoke(playerView);
                        _currentTime = 0f;
                        break;
                    }
                }
            }
        }

        public void Dispose()
        {
            UpdateController.Instance.RemoveUpdatable(this);
        }
    }
}