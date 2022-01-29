using UnityEngine;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `GGJ2022.GameModeSO`. Inherits from `AtomEventReferenceListener&lt;GGJ2022.GameModeSO, GameModeSOEvent, GameModeSOEventReference, GameModeSOUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/GameModeSO Event Reference Listener")]
    public sealed class GameModeSOEventReferenceListener : AtomEventReferenceListener<
        GGJ2022.GameModeSO,
        GameModeSOEvent,
        GameModeSOEventReference,
        GameModeSOUnityEvent>
    { }
}
