using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.MoveFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerFactory : IPlayerFactory
    {
        private PlayerScriptableObject _playerScriptableObject;
        private InputController _inputController;

        public PlayerFactory(PlayerScriptableObject playerScriptableObject, InputController inputController)
        {
            _playerScriptableObject = playerScriptableObject;
            _inputController = inputController;
        }
        
        public PlayerPresenter CreatePlayer(Vector3 position)
        {
            var go = Object.Instantiate(_playerScriptableObject.PlayerPrefab, position, Quaternion.identity);
            var healthModel = new HealthModel(_playerScriptableObject.Health.MaxHealth, _playerScriptableObject.Health.MaxHealth);
            var healthPresenter = new HealthPresenter(healthModel);
            var playerModel = new PlayerModel(go.transform.position, _playerScriptableObject.Speed, _playerScriptableObject.Acceleration);
            var physicsMovement = new PhysicsMovement(go.Rigidbody, playerModel.Speed, playerModel.Acceleration);
            var playerAnimationController = new PlayerAnimationController(go.Animator);
            var playerController = new PlayerPresenter(healthPresenter, playerModel, _inputController, physicsMovement, playerAnimationController, go);
            return playerController;
        }
    }
}