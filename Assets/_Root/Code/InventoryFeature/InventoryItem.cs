using System;
using UnityEngine;

namespace _Root.Code.InventoryFeature
{
    [Serializable]
    public class InventoryItem
    {
        [field: SerializeField] public Sprite Icon { get; set; }
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public bool IsStackable { get; set; }
        [field: SerializeField] public int StackSize { get; set; }
        [field: SerializeField] public int CurrentStack {get; set;}
        [field: SerializeField] public GameObject RealObject { get; set; }

        public InventoryItem(Sprite icon, string name, bool isStackable, int stackSize, int currentStack, GameObject realObject)
        {
            Icon = icon;
            Name = name;
            IsStackable = isStackable;
            StackSize = stackSize;
            CurrentStack = currentStack;
            RealObject = realObject;
        }

        public InventoryItem()
        {
            
        }

        public void AddStack()
        {
            if (IsStackable)
            {
                CurrentStack++;
            }
        }
    }
}