using System;
using _Root.Code.UpdateFeature;
using UnityEngine;

namespace _Root.Code.InventoryFeature
{
    public class PickUpController : IFixedUpdatable, IDisposable
    {
        private Transform _transform;
        private InventoryPresenter _inventoryPresenter;
        private float _pickupRadius = 5f;
        private LayerMask _layerMask;
        private int _layerToPut;

        public PickUpController(Transform transform, InventoryPresenter inventoryPresenter, LayerMask layerMask)
        {
            _transform = transform;
            _inventoryPresenter = inventoryPresenter;
            _layerMask = layerMask;
            _layerToPut = LayerMask.NameToLayer("Default");
        }

        public void GetPickableItems()
        {
            var pickubles = Physics2D.OverlapCircleAll(_transform.position, _pickupRadius, _layerMask);
            foreach (var pickuble in pickubles)
            {
                if (pickuble.TryGetComponent(out IPickable pickable))
                {
                    var inventoryItem = new InventoryItem(pickable.InventoryItemScriptableObject.Icon,
                        pickable.InventoryItemScriptableObject.Name, pickable.InventoryItemScriptableObject.IsStackable,
                        pickable.InventoryItemScriptableObject.MaxStackSize,
                        pickable.InventoryItemScriptableObject.GivenStackSize,
                        pickuble.gameObject);
                    var tryAddItem = _inventoryPresenter.TryAddItem(inventoryItem);
                    if (tryAddItem)
                    {
                        
                        pickuble.gameObject.layer = _layerToPut;
                        pickuble.gameObject.SetActive(false);
                    }
                }
            }
        }
        public void FixedUpdate()
        {
            GetPickableItems();
        }

        public void Dispose()
        {
            UpdateController.Instance.RemoveFixedUpdatable(this);
        }
    }
}