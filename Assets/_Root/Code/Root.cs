using System;
using _Root.Code.HealthFeature;
using _Root.Code.InputFeature;
using _Root.Code.MoveFeature;
using _Root.Code.UpdateFeature;
using Game.Code.PlayerFeature;
using UnityEngine;

namespace _Root.Code
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private PlayerBootstrap _playerBootstrap;
        private void Start()
        {
            var inputController = new InputController(_joystick);
            _playerBootstrap.Initialize(inputController);
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
    }
}