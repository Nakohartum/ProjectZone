using System;
using System.Collections.Generic;

namespace _Root.Code.InventoryFeature
{
    public class InventoryModel
    {
        public List<InventoryItem> Items { get; set; }

        public InventoryModel()
        {
            Items = new List<InventoryItem>();
        }

        public void AddItem(InventoryItem item)
        {
            Items.Add(item);
        }

        [Serializable]
        public struct SaveData
        {
            public List<InventoryItemSaveData> Items;
        }
        
        [Serializable]
        public struct InventoryItemSaveData
        {
            public string IconName;
            public string Name;
            public bool IsStackablel;
            public int StackSize;
            public string RealObject;
            public int CurrentStack;
        }
    }
}