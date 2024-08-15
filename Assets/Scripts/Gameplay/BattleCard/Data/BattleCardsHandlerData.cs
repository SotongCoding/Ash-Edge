using System.Collections.Generic;
using SotongStudio.VContainer;


namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Data
{
    [RegisterAs(typeof(IBattleCardsHandlerData), typeof(IBattleCardsHandlerDataProcessor))]
    public class BattleCardsHandlerData : IBattleCardsHandlerData, IBattleCardsHandlerDataProcessor
    {
        public BattleDeckData PlayerDeckCard { get; private set; }

        public BattleDeckData DeterminedDeckCard { get; private set; }

        public IReadOnlyList<IBattleCard> PlayerHandCards { get; private set; }

        public IReadOnlyList<IBattleCard> DeterminedCards { get; private set; }

        public IReadOnlyList<IBattleCard> PlayedCards => _playedCard;
        private readonly List<IBattleCard> _playedCard = new();

        public IReadOnlyList<IBattleCard> ExecutedCards
        {
            get
            {
                var allCards = new List<IBattleCard>(DeterminedCards);
                allCards.AddRange(PlayedCards);
                return allCards;
            }
        }

        public void SetupDeck(BattleDeckData usedDeck)
        {
            PlayerDeckCard = usedDeck;
            DeterminedDeckCard = usedDeck;
        }

        public void SetupDeterminedCards()
        {
            DeterminedCards = DeterminedDeckCard.GetRandomCards();
        }

        public void SetupPlayerCards()
        {
            PlayerHandCards = PlayerDeckCard.GetRandomCards();
        }

        public bool TryAddPlayedCard(IBattleCard cardData)
        {
            if (_playedCard.Count < 2 && !_playedCard.Contains(cardData))
            {
                _playedCard.Add(cardData);
                return true;
            }
            return false;
        }

        public bool TryRemovePlayedCard(IBattleCard cardData)
        {
            if (!_playedCard.Contains(cardData)) return false;
            
            _playedCard.Remove(cardData);
            _playedCard.Sort();
            return true;
        }

        public (HandRankLogic.HandRanking handRanking, IEnumerable<IBattleCard> usedCards) GetCurrentCardStatus()
        {
            var allCard = new List<IBattleCard>();
            allCard.AddRange(PlayedCards);
            allCard.AddRange(DeterminedCards);

            return HandRankLogic.DetermineCards<IBattleCard>(allCard);

        }
        public void ClearPlayerSelectedCard()
        {
            _playedCard.Clear();
        }
    }
}
