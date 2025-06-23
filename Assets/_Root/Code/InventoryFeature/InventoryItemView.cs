using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Root.Code.InventoryFeature
{
    public class InventoryItemView : MonoBehaviour, IPointerClickHandler
    {
        [field: SerializeField] public Image Icon { get; private set; }
        [field: SerializeField] public TMP_Text Name { get; private set; }
        [field: SerializeField] public TMP_Text CurrentStack { get; private set; }
        public bool Reserved { get; set; }

        public void SetInformation(Sprite icon, string name, string currentStack)
        {
            Icon.gameObject.SetActive(true);
            Name.gameObject.SetActive(true);
            CurrentStack.gameObject.SetActive(true);
            Icon.sprite = icon;
            Name.text = name;
            CurrentStack.text = currentStack;
            Reserved = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }

        public void Clear()
        {
            Icon.gameObject.SetActive(false);
            Name.gameObject.SetActive(false);
            CurrentStack.gameObject.SetActive(false);
            Icon.sprite = null;
            Name.text = "";
            CurrentStack.text = "";
            Reserved = false;
        }
    }
}