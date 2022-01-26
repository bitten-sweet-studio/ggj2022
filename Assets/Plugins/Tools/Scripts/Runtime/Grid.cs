using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace niscolas.UnityUtils.Tools
{
    public class Grid
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public float CellSize { get; private set; }

        public Vector3 OriginPosition { get; private set; }

        public Grid(int width, int height, float cellSize, Vector3 originPosition)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            OriginPosition = originPosition;
        }
    }

    public class Grid<T> : Grid, IEnumerable<T>
    {
        public Action<int, int> ValueChanged;

        private T[,] RawContent { get; }

        public T this[int x, int y]
        {
            get => RawContent[x, y];

            set
            {
                RawContent[x, y] = value;
                ValueChanged?.Invoke(x, y);
            }
        }

        public Grid(
            int width,
            int height,
            float cellSize,
            Vector3 originPosition,
            Func<int, int, Grid<T>, T> createGridCellFunc) :
            base(width, height, cellSize, originPosition)
        {
            RawContent = new T[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    RawContent[i, j] = createGridCellFunc(i, j, this);
                }
            }
        }

        public bool TryGet(int x, int y, out T value)
        {
            if (CheckAreValidCoordinates(x, y))
            {
                value = this[x, y];
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool TryGetByWorldPosition(Vector3 worldPosition, out T value)
        {
            GetXY(worldPosition, out int x, out int y);
            if (CheckAreValidCoordinates(x, y))
            {
                value = this[x, y];
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool TrySet(int x, int y, T value)
        {
            if (!CheckAreValidCoordinates(x, y))
            {
                return false;
            }

            this[x, y] = value;
            return true;
        }

        public void ForceNotifyChanged(int x, int y)
        {
            ValueChanged?.Invoke(x, y);
        }

        public void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPosition - OriginPosition).x / CellSize);
            y = Mathf.FloorToInt((worldPosition - OriginPosition).y / CellSize);
        }

        public Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, y) * CellSize + OriginPosition;
        }

        public void SetByWorldPosition(T value, Vector3 worldPosition)
        {
            GetXY(worldPosition, out int x, out int y);
            this[x, y] = value;
        }

        private bool CheckAreValidCoordinates(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return RawContent.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}