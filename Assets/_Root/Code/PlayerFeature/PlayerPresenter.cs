using System;
using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.InventoryFeature;
using _Root.Code.MoveFeature;
using _Root.Code.SaveFeature;
using _Root.Code.ShootingFeature.Aiming;
using _Root.Code.ShootingFeature.Weapon;
using _Root.Code.UpdateFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerPresenter : IFixedUpdatable, ISaveable, IDisposable
    {
        private HealthPresenter _healthPresenter;
        private IPlayerModel _playerModel;
        private IPlayerView _playerView;
        private InputController _inputController;
        private IMoveable _moveable;
        private Vector2 _moveVector;
        private PlayerAnimationController _playerAnimationController;
        private WeaponPresenter _weaponPresenter;
        private PickUpController _pickUpController;
        private InventoryPresenter _inventoryPresenter;

        public PlayerPresenter(HealthPresenter healthPresenter, IPlayerModel playerModel, InputController inputController, 
            IMoveable moveable, PlayerAnimationController playerAnimationController, IPlayerView playerView, WeaponPresenter weaponPresenter, PickUpController pickUpController, InventoryPresenter inventoryPresenter)
        {
            _healthPresenter = healthPresenter;
            _playerModel = playerModel;
            _inputController = inputController;
            _moveable = moveable;
            _playerAnimationController = playerAnimationController;
            _playerView = playerView;
            _weaponPresenter = weaponPresenter;
            _pickUpController = pickUpController;
            _inventoryPresenter = inventoryPresenter;
            _inputController.OnJoystickMoved.AddListener(SetDirection);
            UpdateController.Instance.AddFixedUpdatable(this);
            _playerView.Initialize(this);
            GetWeapon(_playerView.WeaponView);
            _inputController.ShootButton.onClick.AddListener(_weaponPresenter.Shoot);
            _healthPresenter.OnDeath.AddListener(Die);
        }

        private void Die()
        {
            _playerView.GameObject.SetActive(false);
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
            _playerModel.Position = _playerView.Rigidbody.position;
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

        public void GetWeapon(WeaponView weaponView)
        {
            var weaponModel = new WeaponModel(weaponView.WeaponScriptableObject.Damage, weaponView.WeaponScriptableObject.AmmoInClip, 
                weaponView.WeaponScriptableObject.AmmoInClip, weaponView.WeaponScriptableObject.AttackRange);
            _weaponPresenter.ChangeWeapon(weaponModel, weaponView);
            
        }

        public void GetDamage(float value)
        {
            _healthPresenter.GetDamage(value);
        }

        public string Key => "Player";

        public object Save()
        {
            return new PlayerModel.SaveData
            {
                Health = _healthPresenter.GetHealth(),
                Position = _playerModel.Position
            };
        }

        public void Load(object state)
        {
            string json = state as string;
            if (string.IsNullOrEmpty(json)) return;

            var data = JsonUtility.FromJson<PlayerModel.SaveData>(json);

            _playerModel.Position = data.Position;
            _healthPresenter.SetHealth(data.Health);
            _playerView.Rigidbody.position = _playerModel.Position;
        }

        public void Dispose()
        {
            _inputController.OnJoystickMoved.RemoveListener(SetDirection);
            UpdateController.Instance.RemoveFixedUpdatable(this);
            
            _inputController.ShootButton.onClick.RemoveListener(_weaponPresenter.Shoot);
            _healthPresenter.OnDeath.RemoveListener(Die);
        }
    }

    
}