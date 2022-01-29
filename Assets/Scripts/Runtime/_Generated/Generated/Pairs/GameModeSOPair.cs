using System;
using UnityEngine;
using GGJ2022;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;GGJ2022.GameModeSO&gt;`. Inherits from `IPair&lt;GGJ2022.GameModeSO&gt;`.
    /// </summary>
    [Serializable]
    public struct GameModeSOPair : IPair<GGJ2022.GameModeSO>
    {
        public GGJ2022.GameModeSO Item1 { get => _item1; set => _item1 = value; }
        public GGJ2022.GameModeSO Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private GGJ2022.GameModeSO _item1;
        [SerializeField]
        private GGJ2022.GameModeSO _item2;

        public void Deconstruct(out GGJ2022.GameModeSO item1, out GGJ2022.GameModeSO item2) { item1 = Item1; item2 = Item2; }
    }
}