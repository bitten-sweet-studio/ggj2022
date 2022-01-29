using System;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `GGJ2022.GameModeSO`. Inherits from `AtomEventReference&lt;GGJ2022.GameModeSO, GameModeSOVariable, GameModeSOEvent, GameModeSOVariableInstancer, GameModeSOEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class GameModeSOEventReference : AtomEventReference<
        GGJ2022.GameModeSO,
        GameModeSOVariable,
        GameModeSOEvent,
        GameModeSOVariableInstancer,
        GameModeSOEventInstancer>, IGetEvent 
    { }
}
