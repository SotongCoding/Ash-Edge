using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Data
{
    public class BattleDeckData
    {
        public List<IBattleCard> Cards;
        public BattleDeckData(IEnumerable<IBattleCard> usedCards)
        {
            Cards = new(usedCards);
        }
        public List<IBattleCard> GetRandomCards()
        {
            List<IBattleCard> temp = new(Cards);
            List<IBattleCard> result = new();

            for (int i = 0; i < 5; i++)
            {
                var index = Random.Range(0, temp.Count);
                result.Add(temp[index]);
                temp.RemoveAt(index);
            }

            return result;
        }

        public static BattleDeckData TestDeck = new(
            new BattleCard[]{
                new(1,GameData.Card.CardType.Strike),
                new(1,GameData.Card.CardType.Magic),
                new(1,GameData.Card.CardType.Action),
                new(1,GameData.Card.CardType.Ace),

                new(2,GameData.Card.CardType.Strike),
                new(2,GameData.Card.CardType.Magic),
                new(2,GameData.Card.CardType.Action),
                new(2,GameData.Card.CardType.Ace),

                new(3,GameData.Card.CardType.Strike),
                new(3,GameData.Card.CardType.Magic),
                new(3,GameData.Card.CardType.Action),
                new(3,GameData.Card.CardType.Ace),

                new(4,GameData.Card.CardType.Strike),
                new(4,GameData.Card.CardType.Magic),
                new(4,GameData.Card.CardType.Action),
                new(4,GameData.Card.CardType.Ace),

                new(5,GameData.Card.CardType.Strike),
                new(5,GameData.Card.CardType.Magic),
                new(5,GameData.Card.CardType.Action),
                new(5,GameData.Card.CardType.Ace)
            }
        );
    }
}

