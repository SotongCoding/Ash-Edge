using SotongStudio.AshEdge.Esential.Character.Attribute;
using SotongStudio.AshEdge.GameData.Skill;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Enemy
{

    [CreateAssetMenu(menuName = "Game Data/Master Enemy Data", fileName = "EMY-XXX-Name")]
    public class MasterEnemyConfigData : ContentCollectionItem
    {
        public string MasterEnemyId;
        public EnemyGeneralInfo GeneralInfo;
        public EnemyInitialStat BaseStat;
        public EnemyVisualConfig VisualConfig;
        public EnemyInitialTalentSkill InitialSkills;

        public override string MasterId => MasterEnemyId;
    }

    [System.Serializable]
    public struct EnemyGeneralInfo
    {
        public string EnemyName;
        public string EnemyDescription;
    }

    [System.Serializable]
    public struct EnemyInitialStat : IUnitAttribute
    {
        public int Power => _power;
        public int Defense => _defense;
        public int Health => _health;
        public int EvasionRate => _evasionRate;
        public int BlockRate => _blockRate;
        public int CriticalRate => _criticalRate;
        public int CriticalDamage => _criticalDamage;

        [SerializeField]
        private int _power;
        [SerializeField]
        private int _defense;
        [SerializeField]
        private int _health;
        [SerializeField]
        private int _evasionRate;
        [SerializeField]
        private int _blockRate;
        [SerializeField]
        private int _criticalRate;
        [SerializeField]
        private int _criticalDamage;
    }

    [System.Serializable]
    public struct EnemyVisualConfig
    {
        public Sprite EnemyIcon;
        public RuntimeAnimatorController AnimatorController;
    }

    [System.Serializable]
    public struct EnemyInitialTalentSkill
    {
        public MasterSkillData[] Skills;
    }
}
