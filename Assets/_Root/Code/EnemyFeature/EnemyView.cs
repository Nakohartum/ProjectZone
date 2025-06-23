using System;
using _Root.Code.HealthFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public EnemyPresenter EnemyPresenter { get; private set; }
        [field: SerializeField] public HealthView HealthView { get; private set; }
        [field: SerializeField] public Canvas Canvas { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        public GameObject GameObject => gameObject;


        public void Initialize(EnemyPresenter enemyPresenter)
        {
            EnemyPresenter = enemyPresenter;
        }

        private void OnDisable()
        {
            EnemyPresenter.Dispose();
        }
    }
}