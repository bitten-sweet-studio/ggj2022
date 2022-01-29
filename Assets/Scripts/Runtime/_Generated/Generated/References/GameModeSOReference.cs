using System;
using UnityAtoms.BaseAtoms;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `GGJ2022.GameModeSO`. Inherits from `AtomReference&lt;GGJ2022.GameModeSO, GameModeSOPair, GameModeSOConstant, GameModeSOVariable, GameModeSOEvent, GameModeSOPairEvent, GameModeSOGameModeSOFunction, GameModeSOVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class GameModeSOReference : AtomReference<
        GGJ2022.GameModeSO,
        GameModeSOPair,
        GameModeSOConstant,
        GameModeSOVariable,
        GameModeSOEvent,
        GameModeSOPairEvent,
        GameModeSOGameModeSOFunction,
        GameModeSOVariableInstancer>, IEquatable<GameModeSOReference>
    {
        public GameModeSOReference() : base() { }
        public GameModeSOReference(GGJ2022.GameModeSO value) : base(value) { }
        public bool Equals(GameModeSOReference other) { return base.Equals(other); }
        protected override bool ValueEquals(GGJ2022.GameModeSO other)
        {
            throw new NotImplementedException();
        }
    }
}
