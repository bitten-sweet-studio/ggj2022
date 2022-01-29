#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `GGJ2022.GameModeSO`. Inherits from `AtomDrawer&lt;GameModeSOVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(GameModeSOVariable))]
    public class GameModeSOVariableDrawer : VariableDrawer<GameModeSOVariable> { }
}
#endif
