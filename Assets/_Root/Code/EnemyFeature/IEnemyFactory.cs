using UnityEngine;

namespace _Root.Code.EnemyFeature
{
    public interface IEnemyFactory
    {
        IEnemyView CreateEnemy(EnemyScriptableObject enemy, Transform spawnPoint);
    }
}