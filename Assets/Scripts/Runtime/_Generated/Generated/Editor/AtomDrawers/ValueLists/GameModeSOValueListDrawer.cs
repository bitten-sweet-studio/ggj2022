#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `GGJ2022.GameModeSO`. Inherits from `AtomDrawer&lt;GameModeSOValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(GameModeSOValueList))]
    public class GameModeSOValueListDrawer : AtomDrawer<GameModeSOValueList> { }
}
#endif
