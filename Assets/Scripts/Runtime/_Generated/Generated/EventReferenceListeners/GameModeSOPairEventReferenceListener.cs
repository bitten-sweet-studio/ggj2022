using UnityEngine;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `GameModeSOPair`. Inherits from `AtomEventReferenceListener&lt;GameModeSOPair, GameModeSOPairEvent, GameModeSOPairEventReference, GameModeSOPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/GameModeSOPair Event Reference Listener")]
    public sealed class GameModeSOPairEventReferenceListener : AtomEventReferenceListener<
        GameModeSOPair,
        GameModeSOPairEvent,
        GameModeSOPairEventReference,
        GameModeSOPairUnityEvent>
    { }
}
