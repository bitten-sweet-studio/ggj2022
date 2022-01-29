using UnityEngine;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `GGJ2022.GameModeSO`. Inherits from `AtomValueList&lt;GGJ2022.GameModeSO, GameModeSOEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/GameModeSO", fileName = "GameModeSOValueList")]
    public sealed class GameModeSOValueList : AtomValueList<GGJ2022.GameModeSO, GameModeSOEvent> { }
}
