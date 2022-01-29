using UnityEngine;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `GGJ2022.GameModeSO`. Inherits from `AtomEvent&lt;GGJ2022.GameModeSO&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/GameModeSO", fileName = "GameModeSOEvent")]
    public sealed class GameModeSOEvent : AtomEvent<GGJ2022.GameModeSO>
    {
    }
}
