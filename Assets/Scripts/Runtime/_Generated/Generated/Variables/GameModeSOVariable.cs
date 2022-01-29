using UnityEngine;
using System;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `GGJ2022.GameModeSO`. Inherits from `AtomVariable&lt;GGJ2022.GameModeSO, GameModeSOPair, GameModeSOEvent, GameModeSOPairEvent, GameModeSOGameModeSOFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/GameModeSO", fileName = "GameModeSOVariable")]
    public sealed class GameModeSOVariable : AtomVariable<GGJ2022.GameModeSO, GameModeSOPair, GameModeSOEvent,
        GameModeSOPairEvent, GameModeSOGameModeSOFunction>
    {
        protected override bool ValueEquals(GGJ2022.GameModeSO other)
        {
            return Value.Equals(other);
        }
    }
}