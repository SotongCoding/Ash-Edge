using System.Collections;
using System.Collections.Generic;
using SotongStudio.AshEdge.Gameplay.TurnManager.State.EnemyState;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State
{
    public interface IEnemyTurnState : IStateGroup
    {

    }
    [RegisterAs(typeof(IEnemyTurnState))]
    public class EnemyTurnState : TurnStateGroup, IEnemyTurnState
    {
        public EnemyTurnState(IExecuteEnemyProcess executeProcess)
        {
            StateProceses = new IStateProcess[]
            {
                executeProcess
            };
        }

        public override StateType RunningTurn => StateType.EnemyState;
        public override IEnumerable<IStateProcess> StateProceses { get; protected set; }
    }
}
