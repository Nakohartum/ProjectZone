using System;
using _Root.Code.EnemyFeature;
using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.InventoryFeature;
using _Root.Code.MoveFeature;
using _Root.Code.UpdateFeature;
using Game.Code.PlayerFeature;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Root.Code
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private InputBootstrap _inputBootstrap;
        [SerializeField] private PlayerBootstrap _playerBootstrap;
        [SerializeField] private EnemyBootstrap _enemyBootstrap;
        [SerializeField] private InventoryBootstrap _inventoryBootstrap;
        
        private void Start()
        {
            _inputBootstrap.Initialize();
            _enemyBootstrap.Initialize();
            _inventoryBootstrap.Initialize(_inputBootstrap.InputController);
            _playerBootstrap.Initialize(_inputBootstrap.InputController, _inventoryBootstrap.InventoryView.InventoryPresenter);
            
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            UpdateController.Instance.Update(deltaTime);
        }

        private void FixedUpdate()
        {
            UpdateController.Instance.FixedUpdate();
        }

        private void LateUpdate()
        {
            UpdateController.Instance.LateUpdate();
        }
    }
}