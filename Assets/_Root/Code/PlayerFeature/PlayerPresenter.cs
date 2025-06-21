using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.MoveFeature;
using _Root.Code.UpdateFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerPresenter : IFixedUpdatable
    {
        private HealthPresenter _healthPresenter;
        private IPlayerModel _playerModel;
        private IPlayerView _playerView;
        private InputController _inputController;
        private IMoveable _moveable;
        private Vector2 _moveVector;
        private PlayerAnimationController _playerAnimationController;

        public PlayerPresenter(HealthPresenter healthPresenter, IPlayerModel playerModel, InputController inputController, IMoveable moveable, PlayerAnimationController playerAnimationController, IPlayerView playerView)
        {
            _healthPresenter = healthPresenter;
            _playerModel = playerModel;
            _inputController = inputController;
            _moveable = moveable;
            _playerAnimationController = playerAnimationController;
            _playerView = playerView;
            _inputController.OnJoystickMoved.AddListener(SetDirection);
            UpdateController.Instance.AddFixedUpdatable(this);
            _playerView.Initialize(this);
        }

        private void SetDirection(Vector2 value)
        {
            _moveVector.Set(value.x, value.y);
            TriggerAnimation();
            ChangeSide(_playerView.Rigidbody.velocity);
        }

        private void TriggerAnimation()
        {
            if (_playerView.Rigidbody.velocity.magnitude > 0.01f)
            {
                _playerAnimationController.PlayWalkingState();
            }
            else
            {
                _playerAnimationController.PlayIdleState();
            }
        }

        public void FixedUpdate()
        {
            _moveable.Move(_moveVector);
        }

        private void ChangeSide(Vector3 velocity)
        {
            if (velocity.magnitude > 0.1f)
            {
                ChangeSide(velocity.x < -0.01f);
            }
        }

        private void ChangeSide(bool isRight)
        {
            _playerView.Head.flipX = isRight;
            _playerView.Body.flipX = isRight;
            _playerView.LeftArm.sortingOrder = isRight? 1 : 0;
            _playerView.LeftElbow.sortingOrder = isRight? 1 : 0;
            _playerView.RightArm.sortingOrder = isRight? 0 : 1;
            _playerView.RightElbow.sortingOrder = isRight? 0 : 1;
            var scale = _playerView.LeftLeg.transform.localScale;
            _playerView.RightLeg.flipX = isRight;
            _playerView.LeftLeg.flipX = isRight;
            _playerView.RightLeg.transform.localScale = isRight? Vector3.one : new Vector3(0.59f, scale.y, scale.z);
            _playerView.LeftLeg.transform.localScale = isRight? new Vector3(0.59f, scale.y, scale.z) :  Vector3.one;
        }
    }

    
}