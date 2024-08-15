using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Gameplay.CardMechanic;
using SotongStudio.AshEdge.Gameplay.UI.ActionControl;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State.PlayerState
{
    public interface IPlayerChooseActionProcess : IStateProcess
    {

    }
    [RegisterAs(typeof(IPlayerChooseActionProcess))]
    public class PlayerChooseActionProcess : IPlayerChooseActionProcess
    {
        private readonly IBattleCardsHandlerEventCoordinator _cardEvent;
        private readonly ExecuteActionController _executeControl;

        public PlayerChooseActionProcess(IBattleCardsHandlerEventCoordinator cardEventHandler,
                                         ExecuteActionController executeControl)
        {
            _cardEvent = cardEventHandler;
            _executeControl = executeControl;
        }

        public async UniTask RunAsync(CancellationToken cancellationToken)
        {
            await _cardEvent.OnPlayerDoneChooseCard.OnInvokeAsync(cancellationToken);
            _executeControl.ResetVisual();
        }
    }
}
