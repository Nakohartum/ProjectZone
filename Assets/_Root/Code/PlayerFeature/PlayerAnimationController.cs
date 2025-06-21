using UnityEngine;

namespace Game.Code.PlayerFeature
{
    public class PlayerAnimationController
    {
        private Animator _animator;
        private int _isMovingHash;

        public PlayerAnimationController(Animator animator)
        {
            _animator = animator;
            _isMovingHash = Animator.StringToHash("IsMoving");
        }

        public void PlayIdleState()
        {
            _animator.SetBool(_isMovingHash, false);
        }

        public void PlayWalkingState()
        {
            _animator.SetBool(_isMovingHash, true);
        }
    }
}