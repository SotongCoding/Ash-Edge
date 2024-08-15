using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Skill.Rule
{
    [CreateAssetMenu(fileName = "SKL-RL-XX-Damage Flat", menuName = "Game Data/Skill Rule/Damage Flat", order = 0)]
    public class DealDamageFlat : StrikeRule
    {
        protected override void LogicProcess(BaseBattleUnit executor, IBattleHandledUnits handledUnits)
        {
            UnityEngine.Debug.Log($"Skill Rule : {MasterSkillRuleId} Executed by {executor.UnitControl}");
            int baseDamage = 0;
            BaseBattleUnit targetUnit;

            if (executor is CharacterUnit)
            {
                targetUnit = handledUnits.CurrentEnemyUnit;
            }
            else
            {
                targetUnit = handledUnits.CurrentCharacterUnit;
            }
            var damage = DamageCalculator.CalculateCharacterDamage(executor.Attribute, targetUnit.Attribute);
            targetUnit.Attribute.AddHealth(-damage);

        }
    }
}
