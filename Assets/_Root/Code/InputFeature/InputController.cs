using _Root.Code.UpdateFeature;
using UnityEngine;
using UnityEngine.Events;

namespace _Root.Code.InputFeature
{
    public class InputController : IUpdatable
    {
        private FixedJoystick _fixedJoystick;
        public UnityEvent<Vector2> OnJoystickMoved = new UnityEvent<Vector2>();

        public InputController(FixedJoystick fixedJoystick)
        {
            _fixedJoystick = fixedJoystick;
            UpdateController.Instance.AddUpdatable(this);
        }


        public void Update(float deltaTime)
        {
            OnJoystickMoved.Invoke(_fixedJoystick.Direction);
        }
    }
}