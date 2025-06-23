using _Root.Code.InventoryFeature;
using UnityEngine;

namespace _Root.Code.ShootingFeature.Weapon
{
    public class WeaponView : MonoBehaviour, IPickable
    {
        [field: SerializeField] public WeaponScriptableObject WeaponScriptableObject { get; private set; }
        [field: SerializeField] public InventoryItemScriptableObject InventoryItemScriptableObject { get; private set; }
    }
}