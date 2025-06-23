using _Root.Code.InputFeature;
using UnityEngine;

namespace _Root.Code.InventoryFeature
{
    public class InventoryBootstrap : MonoBehaviour
    {
        [field: SerializeField] public InventoryView InventoryView { get; private set; }
        
        public void Initialize(InputController inputController)
        {
            var inventoryModel = new InventoryModel();
            var inventoryPresenter = new InventoryPresenter(InventoryView, inputController, inventoryModel);
            SaveFeature.Wrapper.Saveables.Add(inventoryPresenter);
            InventoryView.Initialize(inventoryPresenter);
        }
    }
}