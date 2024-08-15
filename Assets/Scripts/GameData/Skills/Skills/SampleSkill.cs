using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Skill
{
    [CreateAssetMenu(fileName = "SKL-XX-Name", menuName = "Game Data/Skill/Sample Skill", order = 0)]
    public class SampleSkill : MasterSkillData
    {
        protected override async UniTask LogicProcessAsync(BaseBattleUnit executor, IBattleHandledUnits handledUnits, CancellationToken cancellationToken)
        {
            UnityEngine.Debug.Log($"Skill {SkillId} Executed by {executor.UnitControl} | And Run sample Skill with Rule");
            foreach (var rule in SkillRules)
            {
                rule.Logic.Invoke(executor, handledUnits);
            }
            await executor.ExecuteAnimationAsync(AnimationData.AnimationKeyOrder, cancellationToken);
        }
    }
}
