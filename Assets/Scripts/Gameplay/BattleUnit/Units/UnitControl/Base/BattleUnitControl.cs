using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace SotongStudio.AshEdge.Gameplay.Unit.Control
{
    public abstract class BattleUnitControl 
    {
        protected readonly BattleUnitView UnitView;
        private readonly CancellationTokenSource _cts = new();

        protected BattleUnitControl(BattleUnitView unitView)
        {
            UnitView = unitView;
        }

        public virtual void Initialize(BaseBattleUnitData unitData)
        {
            UnitView.SetAnimationControl(unitData.VisualData.AnimatorController);
        }

        public async UniTask PlayAnimationSequencedAsync(IEnumerable<string> animationClipsOrder, CancellationToken cancellationToken)
        {
            foreach (var clip in animationClipsOrder)
            {
                await UnitView.PlayAnimationAsync(clip, cancellationToken);
            }
        }
    }
}