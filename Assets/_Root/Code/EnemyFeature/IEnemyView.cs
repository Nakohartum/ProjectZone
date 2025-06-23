using _Root.Code.HealthFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature
{
    public interface IEnemyView
    {
        Rigidbody2D Rigidbody2D { get; }
        EnemyPresenter EnemyPresenter { get; }
        GameObject GameObject { get; }
        HealthView HealthView { get; }
        Canvas Canvas { get; }
        Animator Animator { get; }
        void Initialize(EnemyPresenter enemyPresenter);
    }
}