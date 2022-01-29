#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `GGJ2022.GameModeSO`. Inherits from `AtomDrawer&lt;GameModeSOConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(GameModeSOConstant))]
    public class GameModeSOConstantDrawer : VariableDrawer<GameModeSOConstant> { }
}
#endif
