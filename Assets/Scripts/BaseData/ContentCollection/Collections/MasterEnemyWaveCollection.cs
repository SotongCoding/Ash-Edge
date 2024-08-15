using System.Collections.Generic;
using SotongStudio.AshEdge.BaseData.ContentCollection;
using SotongStudio.AshEdge.GameData.Enemy;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.EnemyWave
{
    [CreateAssetMenu(fileName = "Enemy Wave Contents", menuName = "Content/Collection/Data/Enemy Waves", order = 0)]
    public class MasterEnemyWaveCollection : ContentDataCollection, IContenDataCollection<MasterEnemyWaveData>
    {
        private Dictionary<string, MasterEnemyWaveData> _chacedAsset;
        public Dictionary<string, MasterEnemyWaveData> AllAssets => GetAssets(ref _chacedAsset);

    }
}
