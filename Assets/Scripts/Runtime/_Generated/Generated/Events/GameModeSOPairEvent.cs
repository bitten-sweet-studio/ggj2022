using UnityEngine;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `GameModeSOPair`. Inherits from `AtomEvent&lt;GameModeSOPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/GameModeSOPair", fileName = "GameModeSOPairEvent")]
    public sealed class GameModeSOPairEvent : AtomEvent<GameModeSOPair>
    {
    }
}
