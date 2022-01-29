using UnityEngine;
using GGJ2022;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `GGJ2022.GameModeSO`. Inherits from `AtomEventInstancer&lt;GGJ2022.GameModeSO, GameModeSOEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/GameModeSO Event Instancer")]
    public class GameModeSOEventInstancer : AtomEventInstancer<GGJ2022.GameModeSO, GameModeSOEvent> { }
}
