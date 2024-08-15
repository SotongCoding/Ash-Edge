using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Skill.Parameter
{
    [System.Serializable]
    public struct SkillParameter
    {
        public ParameterType Parameter;
        public short Value;
    }

    public enum ParameterType
    {
        PowerValue,
        DefenseValue,
        HealthValue,

        CriticalChanceValue,
        CriticalDamageValue,
        EvasionValue,
        GuardValue
    }
}
