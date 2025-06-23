using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Root.Code.EnemyFeature
{
    public class EnemyBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private EnemyScriptableObject[] _enemies;
        
        [SerializeField] private Transform _grid;
        [SerializeField] private Tilemap _colissionMap;
        
        private bool[,] _map;
        private int _offsetX, _offsetY;

        public void Initialize()
        {
            _map = AStarUtils.AStarUtils.GenerateWalkableMap(_grid, _colissionMap, out _offsetX, out _offsetY);
            var enemyFactory = new EnemyFactory(_enemies, _spawnPoints, _map, _offsetX, _offsetY, _colissionMap);
            for (int i = 0; i < _enemies.Length; i++)
            {
                enemyFactory.CreateEnemy(_enemies[i], _spawnPoints[i]);
            }
            
        }
    }
}