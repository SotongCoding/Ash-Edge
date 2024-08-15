using System;
using System.Collections.Generic;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Visual;
using SotongStudio.VContainer;
using UnityEngine.Events;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic
{
    public interface IBattleCardsHandler
    {
        void Initialize();
        void SetupNewCards();

    }
    [RegisterAs(typeof(IBattleCardsHandler), typeof(IBattleCardsHandlerEventCoordinator))]
    public class BattleCardsHandler : IBattleCardsHandler, IBattleCardsHandlerEventCoordinator
    {
        private readonly IBattleCardsHandlerDataProcessor _cardDataProcessor;
        private readonly IBattleCardsHandlerData _cardData;

        private readonly IBattleCardVisual _battleCardVisual;

        public BattleCardsHandler(IBattleCardVisual battleCardVisual, IBattleCardsHandlerData data, IBattleCardsHandlerDataProcessor dataProcessor)
        {
            _cardData = data;
            _cardDataProcessor = dataProcessor;
            _battleCardVisual = battleCardVisual;
        }

        public UnityEvent<IBattleCard> OnPlayerCardSelected { get; private set; } = new();
        public UnityEvent<IBattleCard> OnDetermineCardSelected { get; private set; } = new();
        public UnityEvent<IBattleCard> OnPlayedCardSelected { get; private set; } = new();
        public UnityEvent<IEnumerable<IBattleCard>> OnCheckSelectedCards { get; private set; } = new();

        public UnityEvent OnPlayerDoneChooseCard { get; set; } = new();

        public void Initialize()
        {
            OnPlayerCardSelected.AddListener(AddPlayedCard);
            OnPlayedCardSelected.AddListener(RemovePlayedCard);
        }

        public void SetupNewCards()
        {
            _cardDataProcessor.SetupDeck(BattleDeckData.TestDeck);
            _cardDataProcessor.SetupPlayerCards();
            _cardDataProcessor.SetupDeterminedCards();

            _battleCardVisual.UpdatePlayerCard(_cardData.PlayerHandCards);
            _battleCardVisual.UpdateDetermineCard(_cardData.DeterminedCards);

            _cardDataProcessor.ClearPlayerSelectedCard();
            _battleCardVisual.UpdateSelectedCard(_cardData.PlayedCards);
        }

        private void AddPlayedCard(IBattleCard selectedCard)
        {
            var success = _cardDataProcessor.TryAddPlayedCard(selectedCard);
            if (!success) return;

            _battleCardVisual.UpdateSelectedCard(_cardData.PlayedCards);
            OnCheckSelectedCards.Invoke(_cardData.ExecutedCards);
        }

        private void RemovePlayedCard(IBattleCard selectedCard)
        {
            var success = _cardDataProcessor.TryRemovePlayedCard(selectedCard);
            if(!success) return;
            _battleCardVisual.UpdateSelectedCard(_cardData.PlayedCards);
            OnCheckSelectedCards.Invoke(_cardData.ExecutedCards);
        }
    }
}
