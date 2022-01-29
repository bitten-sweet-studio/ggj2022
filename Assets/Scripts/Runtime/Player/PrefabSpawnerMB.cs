using System.Linq;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace GGJ2022
{
    public class PrefabSpawnerMB : AutoTriggerMB
    {
        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private GameModeSO[] _acceptedGameModes;

        [SerializeField]
        private GameModeSOReference _currentGameMode;

        private static readonly ISpawnService SpawnService = new UnityInstantiateService();

        public override void Do()
        {
            if (!_acceptedGameModes.Contains(_currentGameMode.Value))
            {
                return;
            }

            if (!_spawnPoint)
            {
                _spawnPoint = transform;
            }

            SpawnService.Spawn(_prefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}