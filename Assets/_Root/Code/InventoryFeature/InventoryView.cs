using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.InventoryFeature
{
    public class InventoryView : MonoBehaviour
    {
        [field: SerializeField] public InventoryItemView[] Slots { get; private set; }
        [field: SerializeField] public Button CloseInventoryButton { get; private set; }
        public InventoryPresenter InventoryPresenter { get; private set; }

        public void Initialize(InventoryPresenter presenter)
        {
            InventoryPresenter = presenter;
        }

    }
}