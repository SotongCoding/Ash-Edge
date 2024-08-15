using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using SotongStudio.AshEdge.GameData.Skill.Rule;
using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using UnityEditor.Animations;
using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Skill
{
    public abstract class MasterSkillData : ScriptableObject
    {
        public delegate UniTask SkillLogic(BaseBattleUnit executor, IBattleHandledUnits handledUnits, CancellationToken cancellationToken);

        public string SkillId;
        public SkillGeneralInfo GeneralInfo;
        public SkillAnimationData AnimationData;
        public SkillRule[] SkillRules;
        public Sprite SkillIcon;

        public SkillLogic Logic => LogicProcessAsync;
        protected abstract UniTask LogicProcessAsync(BaseBattleUnit executor, IBattleHandledUnits handledUnits, CancellationToken cancellationToken);

#if UNITY_EDITOR
        [Button]
        private void FillAnimationKeys()
        {
            AnimationData.FillAnimationKey();
        }
#endif
    }

    [System.Serializable]
    public struct SkillGeneralInfo
    {
        public string SkillName;
        public string SkillDescription;
    }

    [System.Serializable]
    public struct SkillAnimationData
    {
#if UNITY_EDITOR
        public AnimatorController AnimatorReference;
#endif
        public List<string> AnimationKeyOrder;

#if UNITY_EDITOR
        public void FillAnimationKey()
        {
            AnimationKeyOrder.Clear();
            foreach (var animationClip in AnimatorReference.animationClips)
            {
                AnimationKeyOrder.Add(animationClip.name);
            }
        }
#endif
    }
}
