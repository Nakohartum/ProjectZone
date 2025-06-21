namespace _Root.Code.HealthFeature
{
    public class HealthPresenter
    {
        private HealthModel _healthModel;

        public HealthPresenter(HealthModel healthModel)
        {
            _healthModel = healthModel;
        }

        public void AddHealth(float health)
        {
            _healthModel.Heal(health);
        }

        public void GetDamage(float damage)
        {
            _healthModel.GetDamage(damage);
        }
    }
}