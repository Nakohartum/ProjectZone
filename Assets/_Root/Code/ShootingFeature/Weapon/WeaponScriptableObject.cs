using UnityEngine;

namespace _Root.Code.ShootingFeature.Weapon
{
    [CreateAssetMenu(fileName = nameof(WeaponScriptableObject), menuName = "Create/Weapon/"+nameof(WeaponScriptableObject), order = 0)]
    public class WeaponScriptableObject : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public int AmmoInClip { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
    }
}