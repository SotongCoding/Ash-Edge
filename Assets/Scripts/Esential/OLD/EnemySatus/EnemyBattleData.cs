using System;
using SotongStudio.AshEdge.ModelData.Unit.Status;
using UnityEngine;

namespace SotongStudio.AshEdge.Esential.Unit.Enemy
{
    [CreateAssetMenu(menuName = "Battle/EnemyData", fileName = "EN-00")]
    public class EnemyBattleData : ScriptableObject
    {
        public string EnemyId;
        public TempEnemyStatus EnemyStatus;
        public EnemyGeneralInfo GeneralInfo;

    }

    [System.Serializable]
    public struct TempEnemyStatus : IBaseAttribute
    {
        [SerializeField]
        private int _health;
        [SerializeField]
        private int _power;
        [SerializeField]
        private int _defense;

        public int Health => _health;

        public int Power => _power;

        public int Defense => _defense;
    }
    [System.Serializable]
    public struct EnemyGeneralInfo
    {
        public string Name;
        public GameObject PrefabReference;
        public RuntimeAnimatorController AnimatorController;
    }
}
