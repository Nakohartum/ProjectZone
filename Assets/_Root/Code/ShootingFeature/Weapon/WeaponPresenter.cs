using _Root.Code.EnemyFeature;
using _Root.Code.ShootingFeature.Aiming;
using UnityEngine;

namespace _Root.Code.ShootingFeature.Weapon
{
    public class WeaponPresenter
    {
        private IWeaponModel _currentWeapon;
        private WeaponView _currentView;
        private AimingPresenter _aimingPresenter;
        private TargetGetter _targetGetter;

        public WeaponPresenter(AimingPresenter aimingPresenter, TargetGetter targetGetter)
        {
            _aimingPresenter = aimingPresenter;
            _targetGetter = targetGetter;
        }

        public void ChangeWeapon(IWeaponModel weaponModel, WeaponView weaponView)
        {
            _currentWeapon = weaponModel;
            _currentView = weaponView;
            _targetGetter.SetTargetRadius(_currentWeapon.AttackRange);
        }

        public void Shoot()
        {
            if (_targetGetter.Target != null)
            {
                if (_currentWeapon.CurrentAmmoInClip != 0)
                {
                    _currentWeapon.CurrentAmmoInClip--;
                    _targetGetter.Target.EnemyPresenter.GetDamage(_currentWeapon.Damage);
                }

            }
        }
    }
}