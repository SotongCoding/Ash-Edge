using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Skill.Rule
{
    public delegate void SkillRuleLogic(BaseBattleUnit executor, IBattleHandledUnits handledUnits);

    public abstract class SkillRule : ScriptableObject
    {
        public string MasterSkillRuleId;

        public SkillRuleLogic Logic => LogicProcess;
        protected abstract void LogicProcess(BaseBattleUnit executor, IBattleHandledUnits handledUnits);
    }
}
