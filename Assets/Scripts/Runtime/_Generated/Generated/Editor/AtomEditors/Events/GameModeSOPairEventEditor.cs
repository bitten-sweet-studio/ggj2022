#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using GGJ2022;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `GameModeSOPair`. Inherits from `AtomEventEditor&lt;GameModeSOPair, GameModeSOPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(GameModeSOPairEvent))]
    public sealed class GameModeSOPairEventEditor : AtomEventEditor<GameModeSOPair, GameModeSOPairEvent> { }
}
#endif
