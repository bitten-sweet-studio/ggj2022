using System;
using GGJ2022;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Tools
{
    public class LevelPlayerMB : AutoTriggerMB
    {
        [SerializeField]
        private LevelEditorLoadManagerMB _levelEditorLoadManager;

        [SerializeField]
        private LevelTemplateSO _levelTemplate;

        [SerializeField]
        private GameModeSO _playingGameMode;

        [SerializeField]
        private GameModeSO _levelEditorGameMode;

        [SerializeField]
        private GameModeSOReference _currentGameMode;

        [Header(HeaderTitles.Events)]
        [SerializeField]
        private UnityEvent _onLevelLoaded;

        private void Start() { }

        public override void Do()
        {
            if (!_levelTemplate || !enabled)
            {
                _currentGameMode.Value = _levelEditorGameMode;
                return;
            }

            _currentGameMode.Value = _playingGameMode;
            _levelEditorLoadManager.Load(_levelTemplate);
            _onLevelLoaded?.Invoke();
        }
    }
}