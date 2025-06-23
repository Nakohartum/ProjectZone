using System.Collections.Generic;
using System.Linq;
using _Root.Code.InputFeature;
using _Root.Code.SaveFeature;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.InventoryFeature
{
    public class InventoryPresenter : ISaveable
    {
        private InventoryView _view;
        private InventoryModel _inventoryModel;
        private InputController _inputController;

        public InventoryPresenter(InventoryView view, InputController inputController, InventoryModel inventoryModel)
        {
            _view = view;
            _inputController = inputController;
            _inventoryModel = inventoryModel;
            _inputController.InventoryButton.onClick.AddListener(OpenInventory);
            _view.CloseInventoryButton.onClick.AddListener(CloseInventory);
        }

        public bool TryAddItem(InventoryItem item)
        {
            var inventoryItem = _inventoryModel.Items.FirstOrDefault(q => q.Name == item.Name);
            if (inventoryItem != null)
            {
                inventoryItem.AddStack();
                var inventoryItemView = _view.Slots.FirstOrDefault(q => q.Name.text == inventoryItem.Name);
                inventoryItemView.SetInformation(inventoryItem.Icon, inventoryItem.Name, inventoryItem.IsStackable? inventoryItem.CurrentStack.ToString() : "");
                return true;
            }
            else
            {
                var inventoryItemView = _view.Slots.FirstOrDefault(q=> !q.Reserved);
                if (inventoryItemView != null)
                {
                    _inventoryModel.AddItem(item);
                    inventoryItemView.SetInformation(item.Icon, item.Name, item.IsStackable? item.CurrentStack.ToString() : "");
                    return true;
                }
                
                return false;
            }
        }

        private void AddItemFromLoad(InventoryModel.InventoryItemSaveData item)
        {
            var inventoryItem = new InventoryItem(Resources.Load<Sprite>($"Icons/{item.IconName}"), item.Name,
                item.IsStackablel, item.StackSize, item.CurrentStack,
                Resources.Load<GameObject>($"Objects/{item.RealObject}"));
            TryAddItem(inventoryItem);
        }

        public void CloseInventory()
        {
            _view.gameObject.SetActive(false);
        }

        public void OpenInventory()
        {
            _view.gameObject.SetActive(true);
        }

        public string Key => "Inventory";

        public object Save()
        {
            var items = new List<InventoryModel.InventoryItemSaveData>();
            foreach (var inventoryItem in _inventoryModel.Items)
            {
                items.Add(new InventoryModel.InventoryItemSaveData
                {
                    Name = inventoryItem.Name,
                    IconName = inventoryItem.Icon.name,
                    IsStackablel = inventoryItem.IsStackable,
                    RealObject = inventoryItem.Name,
                    StackSize = inventoryItem.StackSize,
                    CurrentStack = inventoryItem.CurrentStack
                });
            }
            return new InventoryModel.SaveData
            {
                Items = items
            };
        }

        public void Load(object state)
        {
            _inventoryModel.Items.Clear();
            ClearAllSlots();
            string json = state as string;
            if (string.IsNullOrEmpty(json)) return;

            var data = JsonUtility.FromJson<InventoryModel.SaveData>(json);

            foreach (var item in data.Items)
            {
                AddItemFromLoad(item);
            }
        }

        private void ClearAllSlots()
        {
            foreach (var slot in _view.Slots)
            {
                slot.Clear();
            }
        }
    }
}