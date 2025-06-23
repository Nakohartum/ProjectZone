using _Root.Code.UpdateFeature;
using UnityEngine;

namespace _Root.Code.ShootingFeature.Aiming
{
    public class AimingPresenter : ILateUpdatable
    {

        private Transform _weaponHolder;
        private TargetGetter _targetGetter;

        public AimingPresenter(Transform weaponHolder, TargetGetter targetGetter)
        {
            _weaponHolder = weaponHolder;
            _targetGetter = targetGetter;
            UpdateController.Instance.AddLateUpdatable(this);
        }
        
        public void LateUpdate()
        {
            if (_targetGetter.Target != null)
            {
                Vector2 dir = (Vector2)_targetGetter.Target.GameObject.transform.position - (Vector2)_weaponHolder.position;
                float  angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                _weaponHolder.localRotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}