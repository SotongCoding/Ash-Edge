using SotongStudio.AshEdge.GameData.Character;
using SotongStudio.AshEdge.GameData.Skill;
using SotongStudio.AshEdge.Gameplay.Unit.Control;

namespace SotongStudio.AshEdge.Gameplay.Unit
{
    public class CharacterUnit : BaseBattleUnit
    {
        public readonly MasterSkillData[] UsedSkills;
        public CharacterUnit(CharacterUnitData unitData, CharacterUnitControl unitControl, CharacterInitialTalentSkill skillData) : base(unitData, unitControl)
        {
            UsedSkills = new[] { skillData.TestSkill };
        }
    }
}
