namespace _Root.Code.ShootingFeature.Weapon
{
    public interface IWeaponModel
    {
        float Damage { get; }
        int AmmoInClip { get; }
        int CurrentAmmoInClip { get; set; }
        float AttackRange { get; }
    }
}