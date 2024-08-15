using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Card;


namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Data
{
    public interface IBattleCardsHandlerData
    {
        BattleDeckData PlayerDeckCard { get; }
        BattleDeckData DeterminedDeckCard { get; }

        IReadOnlyList<IBattleCard> PlayerHandCards { get; }
        IReadOnlyList<IBattleCard> DeterminedCards { get; }
        IReadOnlyList<IBattleCard> PlayedCards { get; }
        IReadOnlyList<IBattleCard> ExecutedCards { get; }
    }
}
