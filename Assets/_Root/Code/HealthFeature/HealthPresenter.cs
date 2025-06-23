using UnityEngine.Events;

namespace _Root.Code.HealthFeature
{
    public class HealthPresenter
    {
        private HealthModel _healthModel;
        private HealthView _healthView;
        public UnityEvent OnDeath = new UnityEvent();

        public HealthPresenter(HealthModel healthModel, HealthView healthView)
        {
            _healthModel = healthModel;
            _healthView = healthView;
            _healthModel.OnHealthChanged.AddListener(_healthView.ShowHealthBar);
            GetDamage(0f);
        }

        public void AddHealth(float health)
        {
            _healthModel.Heal(health);
        }

        public void GetDamage(float damage)
        {
            _healthModel.GetDamage(damage);
            if (_healthModel.CurrentHealth == 0)
            {
                OnDeath.Invoke();
            }
        }

        public float GetHealth()
        {
            return _healthModel.CurrentHealth;
        }

        public void SetHealth(float savedHealth)
        {
            _healthModel.SetCurrentHealth(savedHealth);
            
        }
    }
}