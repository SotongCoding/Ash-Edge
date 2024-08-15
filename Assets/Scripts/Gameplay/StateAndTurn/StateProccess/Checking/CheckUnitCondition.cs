using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State.Checking
{
    public interface ICheckUnitCondition : IStateProcess
    {
        public UnitConditionState State { get; }
    }
    [RegisterAs(typeof(ICheckUnitCondition))]
    public class CheckUnitCondition : ICheckUnitCondition
    {
        private readonly IBattleHandledUnits _handledUnits;

        public CheckUnitCondition(IBattleHandledUnits battleHandledUnits)
        {
            _handledUnits = battleHandledUnits;
        }

        public UnitConditionState State { get; private set; }

        public UniTask RunAsync(CancellationToken cancellationToken)
        {
            CheckUnitState();
            return UniTask.CompletedTask;
        }
        private void CheckUnitState()
        {
            var characterState = _handledUnits.CurrentCharacterUnit.UnitState;
            var enemyState = _handledUnits.CurrentEnemyUnit.UnitState;

            if (characterState.IsDeath)
            {
                State = UnitConditionState.CharacterDeath;
            }
            else if (enemyState.IsDeath)
            {
                State = UnitConditionState.EnemyDeath;
            }
            else
            {
                State = UnitConditionState.ContinueBattle;
            }
        }
    }

    public enum UnitConditionState
    {
        ContinueBattle,

        CharacterDeath,
        EnemyDeath,
    }
}
