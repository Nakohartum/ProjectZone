namespace _Root.Code.EnemyFeature.StateMachine
{
    public interface IEnemyState
    {
        void Enter();
        void Exit();
        void UpdateState(float deltaTime);
    }
}