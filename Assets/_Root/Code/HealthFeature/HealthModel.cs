using UnityEngine;
using UnityEngine.Events;

namespace _Root.Code.HealthFeature
{
    public class HealthModel
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; set; }
        public UnityEvent<float, float> OnHealthChanged = new UnityEvent<float, float>();

        public HealthModel(float maxHealth, float currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }

        public void GetDamage(float damage)
        {
            CurrentHealth = Mathf.Max(0f, CurrentHealth - damage);
            OnHealthChanged.Invoke(CurrentHealth, MaxHealth);
        }

        public void Heal(float heal)
        {
            CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + heal);
            OnHealthChanged.Invoke(CurrentHealth, MaxHealth);
        }

        public void SetCurrentHealth(float savedHealth)
        {
            CurrentHealth = savedHealth;
            OnHealthChanged.Invoke(CurrentHealth, MaxHealth);
        }
    }
}