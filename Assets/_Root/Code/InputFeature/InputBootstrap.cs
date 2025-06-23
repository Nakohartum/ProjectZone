using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.InputFeature
{
    public class InputBootstrap : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;
        public InputController InputController { get; private set; }
       
        public void Initialize()
        {
            InputController = new InputController(_joystick, _shootButton, _inventoryButton, _saveButton, _loadButton);
        }
    }
}