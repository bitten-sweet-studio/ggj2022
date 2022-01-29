#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `GameModeSOPair`. Inherits from `AtomDrawer&lt;GameModeSOPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(GameModeSOPairEvent))]
    public class GameModeSOPairEventDrawer : AtomDrawer<GameModeSOPairEvent> { }
}
#endif
