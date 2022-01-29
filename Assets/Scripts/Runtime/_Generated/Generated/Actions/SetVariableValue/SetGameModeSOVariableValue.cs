using UnityEngine;
using UnityAtoms.BaseAtoms;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `GGJ2022.GameModeSO`. Inherits from `SetVariableValue&lt;GGJ2022.GameModeSO, GameModeSOPair, GameModeSOVariable, GameModeSOConstant, GameModeSOReference, GameModeSOEvent, GameModeSOPairEvent, GameModeSOVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/GameModeSO", fileName = "SetGameModeSOVariableValue")]
    public sealed class SetGameModeSOVariableValue : SetVariableValue<
        GGJ2022.GameModeSO,
        GameModeSOPair,
        GameModeSOVariable,
        GameModeSOConstant,
        GameModeSOReference,
        GameModeSOEvent,
        GameModeSOPairEvent,
        GameModeSOGameModeSOFunction,
        GameModeSOVariableInstancer>
    { }
}
