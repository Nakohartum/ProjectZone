using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.MoveFeature;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerScriptableObject _playerScriptableObject;
        [SerializeField] private Transform _playerSpawnPoint;
        public PlayerPresenter PlayerPresenter { get; private set; }

        public void Initialize(InputController inputController)
        {
            var playerFactory = new PlayerFactory(_playerScriptableObject, inputController);
            PlayerPresenter = playerFactory.CreatePlayer(_playerSpawnPoint.position);
        }
    }
}