namespace _Root.Code.ShootingFeature.Weapon
{
    public class WeaponModel : IWeaponModel
    {
        public float Damage { get; }
        public int AmmoInClip { get; }
        public int CurrentAmmoInClip { get; set; }
        public float AttackRange { get; }

        public WeaponModel(float damage, int ammoInClip, int currentAmmoInClip, float attackRange)
        {
            Damage = damage;
            AmmoInClip = ammoInClip;
            CurrentAmmoInClip = currentAmmoInClip;
            AttackRange = attackRange;
        }
    }
}