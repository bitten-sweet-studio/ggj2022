using System;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Runtime.LevelEditor
{
    public class Test : CachedMB
    {
        private void Start()
        {
            Debug.DrawLine(new Vector3(-10, 0, 0), new Vector3(10, 0, 0), Color.red, 100);
        }
    }
}