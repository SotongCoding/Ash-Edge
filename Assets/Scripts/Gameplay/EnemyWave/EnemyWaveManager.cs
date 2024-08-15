using System.Collections;
using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Enemy;
using SotongStudio.AshEdge.Service.ContentCollection;
using SotongStudio.AshEdge.Shared.GameData.Battle.Provider;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.WaveManager
{
    public interface IEnemyWaveManager
    {
        void Initialize();
        MasterEnemyConfigData LoadNextEnemy();
    }

    [RegisterAs(typeof(IEnemyWaveManager))]
    public class EnemyWaveManager : IEnemyWaveManager
    {
        private readonly IContentLoaderService _contentLoader;
        private readonly IBattleDataProvider _battleProvider;
        private int _currentEnemyIndex = 0;
        private MasterEnemyWaveData _currentSlectedWave;

        public EnemyWaveManager(IContentLoaderService contentLoader,
                                IBattleDataProvider battleProvider)
        {
            _contentLoader = contentLoader;
            _battleProvider = battleProvider;
        }

        public void Initialize()
        {
            var selectedWaveId = _battleProvider.GetCurrentWaveDataId();
            _currentSlectedWave = _contentLoader.GetEnemyWaveMasterData(selectedWaveId);
        }

        public MasterEnemyConfigData LoadNextEnemy()
        {
            var selected = _currentSlectedWave.Enemies[_currentEnemyIndex];
            _currentEnemyIndex++;
            return selected;
        }
    }
}
