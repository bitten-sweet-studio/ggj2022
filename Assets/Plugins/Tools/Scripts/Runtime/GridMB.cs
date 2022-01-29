using System;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Tools
{
    public abstract class GridMB : CachedMB
    {
        [SerializeField]
        protected IntReference _width = new IntReference(1);

        [SerializeField]
        protected IntReference _height = new IntReference(1);

        [SerializeField]
        protected FloatReference _cellSize = new FloatReference(1);

        public event Action<Grid> InternalGridCreated;

        public abstract Grid BaseGrid { get; }

        protected void NotifyInternalGridCreated()
        {
            InternalGridCreated?.Invoke(BaseGrid);
        }
    }

    public abstract class GridMB<T> : GridMB
    {
        public override Grid BaseGrid => Grid;

        public Grid<T> Grid { get; private set; }

        protected abstract T CreateCell(int x, int y, Grid<T> grid);
        protected virtual void AfterGridCreated() { }

        protected override void Awake()
        {
            base.Awake();

            Grid = new Grid<T>(
                _width,
                _height,
                _cellSize,
                _transform.position,
                CreateCell);

            NotifyInternalGridCreated();

            AfterGridCreated();
        }
    }
}