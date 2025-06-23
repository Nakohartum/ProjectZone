using _Root.Code.SaveFeature;
using _Root.Code.UpdateFeature;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Root.Code.InputFeature
{
    public class InputController : IUpdatable
    {
        private FixedJoystick _fixedJoystick;
        public Button SaveButton { get; private set; }
        public Button LoadButton { get; private set; }
        public Button ShootButton { get; private set; }
        public Button InventoryButton { get; private set; }
        public UnityEvent<Vector2> OnJoystickMoved = new UnityEvent<Vector2>();

        public InputController(FixedJoystick fixedJoystick, Button shootButton, Button inventoryButton, Button saveButton, Button loadButton)
        {
            _fixedJoystick = fixedJoystick;
            ShootButton = shootButton;
            InventoryButton = inventoryButton;
            SaveButton = saveButton;
            LoadButton = loadButton;
            UpdateController.Instance.AddUpdatable(this);
            SaveButton.onClick.AddListener(Wrapper.Save);
            LoadButton.onClick.AddListener(Wrapper.Load);
        }


        public void Update(float deltaTime)
        {
            OnJoystickMoved.Invoke(_fixedJoystick.Direction);
        }
    }
}