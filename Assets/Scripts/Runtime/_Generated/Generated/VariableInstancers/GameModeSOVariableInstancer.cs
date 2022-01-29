using UnityEngine;
using UnityAtoms.BaseAtoms;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `GGJ2022.GameModeSO`. Inherits from `AtomVariableInstancer&lt;GameModeSOVariable, GameModeSOPair, GGJ2022.GameModeSO, GameModeSOEvent, GameModeSOPairEvent, GameModeSOGameModeSOFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/GameModeSO Variable Instancer")]
    public class GameModeSOVariableInstancer : AtomVariableInstancer<
        GameModeSOVariable,
        GameModeSOPair,
        GGJ2022.GameModeSO,
        GameModeSOEvent,
        GameModeSOPairEvent,
        GameModeSOGameModeSOFunction>
    { }
}
