using UnityEngine;

namespace _Root.Code.EnemyFeature
{
    public class EnemyAnimatorController
    {
        private Animator _animator;
        private int _walkingHash;
        private int _attackingHash;

        public EnemyAnimatorController(Animator animator)
        {
            _animator = animator;
            _walkingHash = Animator.StringToHash("Walking");
            _attackingHash = Animator.StringToHash("Attacking");
        }

        public void PlayIdleAnimation()
        {
            _animator.SetBool(_walkingHash, false);
        }
        
        public void PlayWalkingAnimation()
        {
            _animator.SetBool(_walkingHash, true);
        }
        
        public void PlayAttackingAnimation()
        {
            _animator.SetBool(_walkingHash, false);
            _animator.SetTrigger(_attackingHash);
        }
    }
}