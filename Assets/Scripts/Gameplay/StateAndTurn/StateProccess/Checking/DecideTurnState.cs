using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State.Checking
{
    public interface IDecideTurnState : IStateProcess
    {

    }
    [RegisterAs(typeof(IDecideTurnState))]
    public class DecideTurnState : IDecideTurnState
    {
        private readonly ITurnStateManager _turnManager;
        private readonly ICheckUnitCondition _unitCondition;

        public DecideTurnState(ITurnStateManager turnManager,
                               ICheckUnitCondition checkUnitCondition)
        {
            _turnManager = turnManager;
            _unitCondition = checkUnitCondition;
        }

        public UniTask RunAsync(CancellationToken cancellationToken)
        {
            CheckingTurn();
            return UniTask.CompletedTask;
        }

        private void CheckingTurn()
        {
            var condition = _unitCondition.State;
            switch (condition)
            {
                default:
                case UnitConditionState.ContinueBattle:
                    
                    break;
                case UnitConditionState.CharacterDeath:
                    EndBattle();
                    break;
                case UnitConditionState.EnemyDeath:
                    RefreshTurn();
                    break;
            }
        }

        private void RefreshTurn()
        {
            _turnManager.Refresh();
        }

        private void EndBattle()
        {
            _turnManager.EndTurn();
        }
    }
}
