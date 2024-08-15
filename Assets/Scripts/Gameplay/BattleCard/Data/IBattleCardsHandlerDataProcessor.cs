using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Card;
using static HandRankLogic;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Data
{
    public interface IBattleCardsHandlerDataProcessor 
    {
        void SetupDeck(BattleDeckData usedDeck);
        void SetupPlayerCards();
        void SetupDeterminedCards();
        
        bool TryAddPlayedCard(IBattleCard cardData);
        bool TryRemovePlayedCard(IBattleCard cardData);

        (HandRanking handRanking, IEnumerable<IBattleCard> usedCards) GetCurrentCardStatus();
        void ClearPlayerSelectedCard();
    }
}
