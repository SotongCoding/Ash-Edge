using SotongStudio.AshEdge.Esential.Character.Attribute;
using SotongStudio.AshEdge.GameData.Skill;
using SotongStudio.AshEdge.GameData.Talent;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Character
{
    [CreateAssetMenu(menuName = "Game Data/Master Character Data", fileName = "CHR-XXX-Name")]
    public class MasterCharacterData : ContentCollectionItem
    {
        [SerializeField]
        private string MasterCharacterId;
        public CharacterGeneralInfo GeneralInfo;
        public CharacterInitialStat BaseStat;
        public CharacterVisuaConfig VisualConfig;
        public CharacterInitialTalentSkill InitialSkills;

        public override string MasterId => MasterCharacterId;
    }

    [System.Serializable]
    public struct CharacterGeneralInfo
    {
        public string CharacterName;
        public string CharacterDescription;
    }

    [System.Serializable]
    public struct CharacterInitialStat : IUnitAttribute
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
    public struct CharacterVisuaConfig
    {
        public Sprite CharacterIcon;
        public RuntimeAnimatorController AnimatorController;
    }

    [System.Serializable]
    public struct CharacterInitialTalentSkill
    {
        public MasterSkillData TestSkill;
        public MasterTalentData TestTalent;
        
        [Space]
        public string Rank1SkillId;
        public string Rank2SkillId;
        public string Rank3SkillId;
        public string Rank4SkillId;
        public string Rank5SkillId;
        public string Rank6SkillId;
        public string Rank7SkillId;
        public string Rank8SkillId;
        public string Rank9SkillId;
        public string Rank10SkillId;
        [Space]
        public string CharacterTalentMasterId;
    }
}
