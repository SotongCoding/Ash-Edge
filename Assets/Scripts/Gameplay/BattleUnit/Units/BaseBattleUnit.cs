using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Esential.Character.Attribute;
using SotongStudio.AshEdge.Gameplay.Unit.Control;
using SotongStudio.AshEdge.Gameplay.Unit.Control.UnitState;

namespace SotongStudio.AshEdge.Gameplay.Unit
{
    public abstract class BaseBattleUnit
    {
        protected BaseBattleUnitData UnitData { get; set; }
        public BattleUnitControl UnitControl { get; protected set; }

        public BattleUnitVisualData VisualData => UnitData.VisualData;
        public CharacterAttribute BaseAttribute => UnitData.BaseAttribute;
        public ModifiedCharacterAttribute Attribute => UnitData.ModifiedAttribute;
        public IBattleUnitState UnitState => UnitData.UnitState;

        protected BaseBattleUnit(BaseBattleUnitData unitData, BattleUnitControl unitControl)
        {
            UnitData = unitData;
            UnitControl = unitControl;
        }

        public virtual void Initialize()
        {
            UnitControl.Initialize(UnitData);
        }
        public virtual UniTask ExecuteAnimationAsync(IEnumerable<string> animationClipsOrder, CancellationToken cancellationToken)
        {
            return UnitControl.PlayAnimationSequencedAsync(animationClipsOrder, cancellationToken);
        }
    }
}
