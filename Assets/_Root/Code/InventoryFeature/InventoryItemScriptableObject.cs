using UnityEngine;

namespace _Root.Code.InventoryFeature
{
    [CreateAssetMenu(fileName = nameof(InventoryItemScriptableObject), menuName = "Create/Inventory/"+nameof(InventoryItemScriptableObject), order = 0)]
    public class InventoryItemScriptableObject : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public bool IsStackable;
        public int MaxStackSize;
        public int GivenStackSize;
        public GameObject ObjectToSpawn;
    }

    public interface IPickable
    {
        InventoryItemScriptableObject InventoryItemScriptableObject { get; }
    }
}