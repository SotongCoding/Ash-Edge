using System;
using System.Collections.Generic;
using System.Linq;
using SotongStudio.AshEdge.Gameplay.CardMechanic;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using VContainer;

namespace SotongStudio.AshEdge.Gameplay.UI.ActionControl
{
    public class ExecuteActionController : IDisposable
    {
        private readonly ExecuteActionView _view;
        private IBattleCardsHandlerEventCoordinator _cardEvent;

        public ExecuteActionController(ExecuteActionView view)
        {
            _view = view;
        }

        [Inject]
        private void Inject(IBattleCardsHandlerEventCoordinator cardEvent)
        {
            _cardEvent = cardEvent;

            Setup();
        }

        private void Setup()
        {
            _view.OnExecuteEvent.AddListener(DoneChooseCard);
            _cardEvent.OnCheckSelectedCards.AddListener(SetInteractable);
        }

        private void SetInteractable(IEnumerable<IBattleCard> cards)
        {
            _view.SetInteractable(cards.Count() > 5);
        }

        private void DoneChooseCard()
        {
            _cardEvent.OnPlayerDoneChooseCard.Invoke();
        }

        public void ResetVisual()
        {
            _view.SetInteractable(false);
        }


        public void Dispose()
        {
            _view.OnExecuteEvent.RemoveListener(DoneChooseCard);
            _cardEvent.OnCheckSelectedCards.RemoveListener(SetInteractable);
        }
    }
}
