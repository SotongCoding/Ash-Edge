using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Gameplay.CardMechanic;
using SotongStudio.AshEdge.Gameplay.UI.ActionControl;
using SotongStudio.VContainer;


namespace SotongStudio.AshEdge.Gameplay.TurnManager.State.PlayerState
{
    public interface ISetupCharacterCardProcess : IStateProcess
    {

    }
    [RegisterAs(typeof(ISetupCharacterCardProcess))]
    public class SetupCharacterCardProcess : ISetupCharacterCardProcess
    {
        private readonly IBattleCardsHandler _battleCardHandler;
        public SetupCharacterCardProcess(IBattleCardsHandler battleCardsHandler)
        {
            _battleCardHandler = battleCardsHandler;
        }

        public UniTask RunAsync(CancellationToken cancellationToken)
        {
            _battleCardHandler.SetupNewCards();
            return UniTask.CompletedTask;
        }
    }
}
