using System.Linq;
using System.Threading.Tasks;
using _Root.Code.UpdateFeature;
using AStar;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Root.Code.MoveFeature
{
    public class AStarMovement : IMoveable, IUpdatable
    {
        private Transform _transform;
        private bool[,] _map;
        private Tilemap _tilemap;
        private int _offsetX;
        private int _offsetY;
        private Vector3[] _path;
        private int _waypoint;
        private float _speed;
        private float _tolerance = 0.1f;

        public AStarMovement(Transform transform, bool[,] map, Tilemap tilemap, int offsetX, int offsetY, float speed)
        {
            _transform = transform;
            _map = map;
            _tilemap = tilemap;
            _offsetX = offsetX;
            _offsetY = offsetY;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            CalculateRoute(direction);
        }

        public bool IsMoving => _path is { Length: > 0 };

        private async Task CalculateRoute(Vector2 direction)
        {
            Vector3Int start = _tilemap.WorldToCell(_transform.position);
            Vector3Int end = _tilemap.WorldToCell(direction);
            int sx = start.x - _offsetX;
            int sy = start.y - _offsetY;
            
            int ex = end.x - _offsetX;
            int ey = end.y - _offsetY;
            var nodes = await AStarPathfinding.GeneratePath(sx, sy, ex, ey, _map, walkableDiagonals:true);
            _path =  nodes
                .Select(n => new Vector3Int(n.Item1 + _offsetX, n.Item2 + _offsetY, 0))
                .Select(c => _tilemap.GetCellCenterWorld(c))
                .ToArray();
        }

        public void Update(float deltaTime)
        {
            if (_path == null || _waypoint >= _path.Length)
            {
                return;
            }
            Vector3 target = _path[_waypoint];
            Vector3 dir = (target - _transform.position).normalized;
            _transform.Translate(dir * _speed * deltaTime);

            if ((_transform.position - target).sqrMagnitude < _tolerance*_tolerance)
                _waypoint++;
        }
    }
}