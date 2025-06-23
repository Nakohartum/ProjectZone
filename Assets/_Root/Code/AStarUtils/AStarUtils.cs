using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Root.Code.AStarUtils
{
    public class AStarUtils
    {
        public static bool[,] GenerateWalkableMap(
            Transform gridTransform,
            Tilemap   collisionMap,
            out int   offsetX,
            out int   offsetY
        )
        {
            var maps = gridTransform.GetComponentsInChildren<Tilemap>();

            var allBounds = maps
                .Select(m => m.cellBounds)
                .Aggregate((a, b) =>
                {
                    var minPos = new Vector3Int(
                        Math.Min(a.xMin, b.xMin),
                        Math.Min(a.yMin, b.yMin),
                        0
                    );
                    var maxPos = new Vector3Int(
                        Math.Max(a.xMax, b.xMax),
                        Math.Max(a.yMax, b.yMax),
                        1
                    );
                    var size = maxPos - minPos;  

                    return new BoundsInt(minPos, size);
                });

            int width  = allBounds.size.x;
            int height = allBounds.size.y;
            offsetX = allBounds.xMin;
            offsetY = allBounds.yMin;

            var walkable = new bool[width, height];

            for (int ix = 0; ix < width; ix++)
            for (int iy = 0; iy < height; iy++)
            {
                var cell = new Vector3Int(allBounds.xMin + ix,
                    allBounds.yMin + iy,
                    0);

                // Блокируем, только если в collisionMap есть тайл
                bool blocked = collisionMap.HasTile(cell);
                walkable[ix, iy] = !blocked;
            }

            return walkable;
        }
    }
}