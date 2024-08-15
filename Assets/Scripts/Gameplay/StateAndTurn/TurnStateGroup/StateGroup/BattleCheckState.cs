using System.Collections.Generic;
using SotongStudio.AshEdge.Gameplay.TurnManager.State.Checking;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State
{
    public interface IBattleCheckState : IStateGroup
    {

    }
    [RegisterAs(typeof(IBattleCheckState))]
    public class BattleCheckState : TurnStateGroup, IBattleCheckState
    {
        public BattleCheckState(IDecideTurnState decideTurn,
                                ICheckUnitCondition checkingUnit,
                                ICinematicCheck cinematicCheck)
        {
            StateProceses = new IStateProcess[]
            {
                checkingUnit,
                cinematicCheck,
                decideTurn
            };
        }

        public override StateType RunningTurn => StateType.CheckingState;

        public override IEnumerable<IStateProcess> StateProceses { get; protected set; }
    }
}
