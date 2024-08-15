using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Enemy
{
    [CreateAssetMenu(menuName = "Game Data/Enemy Wave Data", fileName = "EWV-XXX-Name")]
    public class MasterEnemyWaveData :ContentCollectionItem
    {
        [SerializeField]
        private string WaveId;
        public MasterEnemyConfigData[] Enemies;

        public override string MasterId => WaveId;
    }
}
