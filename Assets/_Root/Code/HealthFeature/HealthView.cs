using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.HealthFeature
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        public void ShowHealthBar(float currentHealth, float maxHealth)
        {
            var localScale = _healthBar.transform.localScale;
            localScale.x = currentHealth / maxHealth;
            _healthBar.transform.localScale = localScale;
        }
    }
}