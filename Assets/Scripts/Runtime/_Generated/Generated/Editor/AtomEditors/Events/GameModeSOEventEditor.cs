#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using GGJ2022;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `GGJ2022.GameModeSO`. Inherits from `AtomEventEditor&lt;GGJ2022.GameModeSO, GameModeSOEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(GameModeSOEvent))]
    public sealed class GameModeSOEventEditor : AtomEventEditor<GGJ2022.GameModeSO, GameModeSOEvent> { }
}
#endif
