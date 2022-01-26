using System;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Tools
{
    public class GridCreatorUtility
    {
        public enum PivotType
        {
            Center,
            Default
        }

        private static readonly ISpawnService SpawnService = new UnityInstantiateService();

        public static GameObject[] Create(
            GameObject tile,
            Vector3Int quantity,
            Vector3 offset,
            Transform parent = null,
            PivotType pivotType = PivotType.Default)
        {
            if (!tile)
            {
                return default;
            }

            GameObject[] tiles = new GameObject[quantity.x * quantity.y * quantity.z];

            Vector3 gridOffset = ComputeGridOffsetByPivotType(quantity, offset, pivotType);

            int counter = 0;
            for (int i = 0; i < quantity.x; i++)
            {
                for (int j = 0; j < quantity.y; j++)
                {
                    for (int k = 0; k < quantity.z; k++)
                    {
                        GameObject tileInstance = CreateTile(tile, offset, parent, i, j, k, gridOffset);

                        tiles[counter] = tileInstance;
                        counter++;
                    }
                }
            }

            return tiles;
        }

        private static Vector3 ComputeGridOffsetByPivotType(Vector3Int quantity, Vector3 offset, PivotType pivotType)
        {
            Vector3 gridOffset;
            switch (pivotType)
            {
                case PivotType.Center:
                    gridOffset = ComputeGridOffset(quantity, offset);
                    break;

                case PivotType.Default:
                    gridOffset = Vector3.zero;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(pivotType), pivotType, null);
            }

            return gridOffset;
        }

        private static GameObject CreateTile(
            GameObject tile,
            Vector3 offset,
            Transform parent,
            int i,
            int j,
            int k,
            Vector3 gridOffset,
            ISpawnService spawnService = null)
        {
            Vector3 position = ComputeTilePosition(i, j, k, offset, gridOffset);

            if (spawnService.IsUnityNull())
            {
                spawnService = SpawnService;
            }

            GameObject tileInstance = spawnService.Spawn(tile, parent);
            tileInstance.transform.localPosition = position;

            return tileInstance;
        }

        public static Vector3 ComputeGridOffset(Vector3Int quantity, Vector3 offset)
        {
            Vector3 result = -(offset.Multiply(quantity - Vector3Int.one) * 0.5f);
            return result;
        }

        public static void UpdateTilesPositions(GameObject[] tiles, Vector3Int quantity, Vector3 offset)
        {
            Vector3 gridOffset = ComputeGridOffset(quantity, offset);

            int counter = 0;
            for (int i = 0; i < quantity.x; i++)
            {
                for (int j = 0; j < quantity.y; j++)
                {
                    for (int k = 0; k < quantity.z; k++)
                    {
                        tiles[counter].transform.localPosition = ComputeTilePosition(i, j, k, offset, gridOffset);
                        counter++;
                    }
                }
            }
        }

        public static Vector3 ComputeTilePosition(int i, int j, int k, Vector3 offset, Vector3 gridOffset)
        {
            Vector3 position = new Vector3
            {
                x = offset.x * i + gridOffset.x,
                y = offset.y * j + gridOffset.y,
                z = offset.z * k + gridOffset.z
            };

            return position;
        }
    }
}