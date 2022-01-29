using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.Tools
{
    [CreateAssetMenu(
        menuName = Constants.CreateAssetMenuPrefix + "Layer Type",
        order = Core.Constants.CreateAssetMenuOrder)]
    public class LayerTypeSO : ScriptableObject
    {
        [SerializeField]
        private IntReference _layerNumber;

        [SerializeField]
        private FloatReference _zPosition;

        public int LayerNumber => _layerNumber;

        public float ZPosition => _zPosition.Value;
    }
}