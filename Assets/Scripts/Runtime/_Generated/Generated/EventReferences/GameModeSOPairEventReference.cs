using System;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `GameModeSOPair`. Inherits from `AtomEventReference&lt;GameModeSOPair, GameModeSOVariable, GameModeSOPairEvent, GameModeSOVariableInstancer, GameModeSOPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class GameModeSOPairEventReference : AtomEventReference<
        GameModeSOPair,
        GameModeSOVariable,
        GameModeSOPairEvent,
        GameModeSOVariableInstancer,
        GameModeSOPairEventInstancer>, IGetEvent 
    { }
}
