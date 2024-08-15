using System.Collections.Generic;
using SotongStudio.AshEdge.Gameplay.TurnManager.State.PlayerState;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State
{
    public interface IPlayerTurnState : IStateGroup
    {

    }
    [RegisterAs(typeof(IPlayerTurnState))]
    public class PlayerTurnState : TurnStateGroup, IPlayerTurnState
    {
        public PlayerTurnState(ISetupCharacterCardProcess setupCard,
                               IPlayerChooseActionProcess chooseAction,
                               IExecuteCharacterActionProcess executeAction)
        {
            StateProceses = new IStateProcess[]
            {
                setupCard,
                chooseAction,
                executeAction
            };
        }

        public override StateType RunningTurn => StateType.CharacterState;
        public override IEnumerable<IStateProcess> StateProceses { get; protected set; }
    }
}
