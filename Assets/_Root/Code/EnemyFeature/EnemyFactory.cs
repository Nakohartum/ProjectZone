using _Root.Code.EnemyFeature.StateMachine;
using _Root.Code.HealthFeature;
using _Root.Code.MoveFeature;
using _Root.Code.UpdateFeature;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Root.Code.EnemyFeature
{
    public class EnemyFactory : IEnemyFactory
    {
        private EnemyScriptableObject[] _enemies;
        private Transform[] _spawnPoints;
        private bool[,] _map;
        private int _offsetX;
        private int _offsetY;
        private Tilemap _tilemap;

        public EnemyFactory(EnemyScriptableObject[] enemies, Transform[] spawnPoints, bool[,] map, int offsetX, int offsetY, Tilemap tilemap)
        {
            _enemies = enemies;
            _spawnPoints = spawnPoints;
            _map = map;
            _offsetX = offsetX;
            _offsetY = offsetY;
            _tilemap = tilemap;
        }
        
        public IEnemyView CreateEnemy(EnemyScriptableObject enemy, Transform spawnPoint)
        {
            var go = Object.Instantiate(enemy.EnemyPrefab,
                spawnPoint.position, Quaternion.identity);
            var enemyModel = new EnemyModel(enemy.Speed, enemy.Acceleration, enemy.RadiusOfAttack, enemy.Damage, enemy.AttackCooldown, enemy.InventoryItem);
            var healthModel = new HealthModel(enemy.Health.MaxHealth, enemy.Health.MaxHealth);
            go.Canvas.worldCamera = Camera.main;
            var playerChecker = new PlayerChecker(go.GameObject.transform);
            var healthPresenter = new HealthPresenter(healthModel, go.HealthView);
            var aStarMovement = new AStarMovement(go.GameObject.transform, _map, _tilemap, _offsetX, _offsetY,
                enemyModel.Speed);
            var animationController = new EnemyAnimatorController(go.Animator);
            var enemyStateMachine = new EnemyStateMachine(animationController);
            var chasingState = new ChasingState(playerChecker, enemyStateMachine, enemyModel, go, aStarMovement);
            var attackingState =
                new AttackingState(enemyModel.Damage, enemyModel.RadiusOfAttack, enemyStateMachine, go.GameObject.transform, enemyModel.AttackCooldown);
            enemyStateMachine.AddState(chasingState.GetType(), chasingState);
            enemyStateMachine.AddState(attackingState.GetType(), attackingState);
            var enemyPresenter = new EnemyPresenter(enemyModel, healthPresenter, go, aStarMovement, playerChecker, enemyStateMachine);
            UpdateController.Instance.AddUpdatable(playerChecker);
            UpdateController.Instance.AddUpdatable(aStarMovement);
            UpdateController.Instance.AddUpdatable(enemyStateMachine);
            return go;
        }
    }
}