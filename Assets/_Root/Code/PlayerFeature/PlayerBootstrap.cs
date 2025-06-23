using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.InventoryFeature;
using _Root.Code.SaveFeature;
using Cinemachine;
using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerScriptableObject _playerScriptableObject;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private CinemachineTargetGroup _cinemachineTargetGroup;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private LayerMask _layerMask;
        public IPlayerView PlayerView { get; private set; }

        public void Initialize(InputController inputController, InventoryPresenter inventoryPresenter)
        {
            var playerFactory = new PlayerFactory(_playerScriptableObject, inputController, _healthView, inventoryPresenter, _layerMask);
            PlayerView = playerFactory.CreatePlayer(_playerSpawnPoint.position);
            Wrapper.Saveables.Add(PlayerView.PlayerPresenter);
            _cinemachineTargetGroup.AddMember(PlayerView.GameObject.transform, 1f, 5f);
        }
    }
}