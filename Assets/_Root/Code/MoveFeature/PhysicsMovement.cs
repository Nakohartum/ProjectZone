using UnityEngine;

namespace _Root.Code.MoveFeature
{
    public class PhysicsMovement : IMoveable
    {
        private Rigidbody2D _rigidbody2D;
        private float _speed;
        private float _acceleration;
        public bool IsMoving => _rigidbody2D.velocity != Vector2.zero;

        public PhysicsMovement(Rigidbody2D rigidbody2D, float speed, float acceleration)
        {
            _rigidbody2D = rigidbody2D;
            _speed = speed;
            _acceleration = acceleration;   
        }
        
        public void Move(Vector2 direction)
        {
            _rigidbody2D.AddForce(direction * _acceleration);
            if (_rigidbody2D.velocity.magnitude > _speed)
            {
                _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _speed;
            }
        }

        
    }
}