#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `GGJ2022.GameModeSO`. Inherits from `AtomDrawer&lt;GameModeSOEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(GameModeSOEvent))]
    public class GameModeSOEventDrawer : AtomDrawer<GameModeSOEvent> { }
}
#endif
