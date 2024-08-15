using System.Collections.Generic;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public interface IBattleCardVisual
    {
        void UpdateDetermineCard(IReadOnlyList<IBattleCard> determinedCards);
        void UpdatePlayerCard(IReadOnlyList<IBattleCard> playedCards);
        void UpdateSelectedCard(IReadOnlyList<IBattleCard> playedCards);
    }
    [RegisterAs(typeof(IBattleCardVisual))]
    public class BattleCardVisual : IBattleCardVisual
    {
        private readonly IReadOnlyList<PlayerCardVisualControl> _playerCardVisuals;
        private readonly IReadOnlyList<DetermineCardVisualControl> _determineCardVisuals;
        private readonly IReadOnlyList<PlayedCardVisualControl> _playedCardVisuals;

        public BattleCardVisual(IReadOnlyList<PlayerCardVisualControl> playerCardVisuals,
                                IReadOnlyList<DetermineCardVisualControl> determineCardVisuals,
                                IReadOnlyList<PlayedCardVisualControl> playedCardVisuals)
        {
            _playerCardVisuals = playerCardVisuals;
            _determineCardVisuals = determineCardVisuals;
            _playedCardVisuals = playedCardVisuals;
        }

        public void UpdateDetermineCard(IReadOnlyList<IBattleCard> determinedCards)
        {
            for (int i = 0; i < determinedCards.Count; i++)
            {
                _determineCardVisuals[i].Setup(determinedCards[i]);
            }
        }

        public void UpdatePlayerCard(IReadOnlyList<IBattleCard> playerCards)
        {
            for (int i = 0; i < playerCards.Count; i++)
            {
                _playerCardVisuals[i].Setup(playerCards[i]);
            }
        }

        public void UpdateSelectedCard(IReadOnlyList<IBattleCard> playedCards)
        {
            int i = 0;
            for (; i < playedCards.Count; i++)
            {
                _playedCardVisuals[i].Setup(playedCards[i]);
            }
            for (; i < 2; i++)
            {
                _playedCardVisuals[i].ResetCardVisual();
            }
        }
    }
}
