using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.InventoryFeature;
using _Root.Code.MoveFeature;
using _Root.Code.ShootingFeature.Aiming;
using _Root.Code.ShootingFeature.Weapon;
using _Root.Code.UpdateFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerFactory : IPlayerFactory
    {
        private PlayerScriptableObject _playerScriptableObject;
        private InputController _inputController;
        private HealthView _healthView;
        private InventoryPresenter _inventoryPresenter;
        private LayerMask _layerMask;

        public PlayerFactory(PlayerScriptableObject playerScriptableObject, InputController inputController, HealthView healthView, InventoryPresenter inventoryPresenter, LayerMask layerMask)
        {
            _playerScriptableObject = playerScriptableObject;
            _inputController = inputController;
            _healthView = healthView;
            _inventoryPresenter = inventoryPresenter;
            _layerMask = layerMask;
        }
        
        public IPlayerView CreatePlayer(Vector3 position)
        {
            var go = Object.Instantiate(_playerScriptableObject.PlayerPrefab, position, Quaternion.identity);
            var healthModel = new HealthModel(_playerScriptableObject.Health.MaxHealth, _playerScriptableObject.Health.MaxHealth);
            var healthPresenter = new HealthPresenter(healthModel, _healthView);
            var playerModel = new PlayerModel(go.transform.position, _playerScriptableObject.Speed, _playerScriptableObject.Acceleration);
            var physicsMovement = new PhysicsMovement(go.Rigidbody, playerModel.Speed, playerModel.Acceleration);
            var playerAnimationController = new PlayerAnimationController(go.Animator);
            var targetGetter = new TargetGetter(go.Rigidbody);
            var aimingPresenter = new AimingPresenter(go.WeaponHolder, targetGetter);
            var weaponPresenter = new WeaponPresenter(aimingPresenter, targetGetter);
            var pickupController = new PickUpController(go.transform, _inventoryPresenter,_layerMask);
            var playerController = new PlayerPresenter(healthPresenter, playerModel, _inputController,
                physicsMovement, playerAnimationController, go, weaponPresenter, pickupController, _inventoryPresenter);
            UpdateController.Instance.AddFixedUpdatable(pickupController);
            return go;
        }
    }
}