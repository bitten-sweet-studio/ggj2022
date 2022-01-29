using UnityEditor;
using UnityAtoms.Editor;
using GGJ2022;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `GGJ2022.GameModeSO`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(GameModeSOVariable))]
    public sealed class GameModeSOVariableEditor : AtomVariableEditor<GGJ2022.GameModeSO, GameModeSOPair> { }
}
