using System.Collections.Generic;
using System.Linq;
using SotongStudio.AshEdge.GameData.Card;

#nullable enable

public class HandRankLogic
{
    public static (HandRanking handRanking, IEnumerable<T> usedCards) DetermineCards<T>(IEnumerable<ICard> inputCard) where T : ICard
    {
        // Mengurutkan kartu berdasarkan nilai

        inputCard.OrderByDescending(card => card.CardPower);
        // hand.OrderByDescending(card => card.CardPower);

        // Cek tangan poker
        if (IsStraightFlush(inputCard, out var straightFlushCard))
        {
            return (HandRanking.StraightFlush, (IEnumerable<T>)straightFlushCard);
        }
        else if (IsFourOfAKind(inputCard, out var fourKindCard))
        {
            return (HandRanking.StraightFlush, (IEnumerable<T>)fourKindCard);
        }
        else if (IsFullHouse(inputCard, out var fullHouseCard))
        {
            return (HandRanking.FullHouse, (IEnumerable<T>)fullHouseCard);
        }
        else if (IsFlush(inputCard, out var flushCard))
        {
            return (HandRanking.Flush, (IEnumerable<T>)flushCard);
        }
        else if (IsStraight(inputCard, out var straightCard))
        {
            return (HandRanking.Straight, (IEnumerable<T>)straightCard);
        }
        else if (IsThreeOfAKind(inputCard, out var threeKindCard))
        {
            return (HandRanking.ThreeOfKind, (IEnumerable<T>)threeKindCard);
        }
        else if (IsTwoPair(inputCard, out var twoPairCard))
        {
            return (HandRanking.TwoPair, (IEnumerable<T>)twoPairCard);
        }
        else if (IsOnePair(inputCard, out var onePairCard))
        {
            return (HandRanking.OnePair, (IEnumerable<T>)onePairCard);
        }
        else
        {
            return (HandRanking.HighCard, new T[] { (T)inputCard.First() });
        }
    }
    private static List<CustomCardCountData> GetCardCount(IEnumerable<ICard> hand)
    {
        // Fungsi untuk menghitung jumlah masing-masing nilai kartu
        List<CustomCardCountData> cardCount = new();
        foreach (var card in hand)
        {
            var handCardNumber = card.CardPower;
            var handCardType = card.CardType;

            int cardCountIndex = cardCount.FindIndex(x => x.CardNumber == handCardNumber);
            if (cardCountIndex != -1)
            {
                cardCount[cardCountIndex].Amount += 1;
                cardCount[cardCountIndex].CardsIncluded.Add(card);

                if (!cardCount[cardCountIndex].CardTypesIncluded.Contains(handCardType))
                {
                    cardCount[cardCountIndex].CardTypesIncluded.Add(handCardType);
                }
            }
            else
            {
                cardCount.Add(new CustomCardCountData(handCardNumber, 1,
                            new List<ICard>() { card }, new List<CardType>() { handCardType }));
            }
        }
        cardCount.OrderByDescending(x => x.CardNumber);
        return cardCount;
    }

    private static bool IsStraightFlush(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCard)
    {
        var cardUsed = new List<ICard>();

        var straight = IsStraight(hand, out var usedCards1);
        var flush = IsFlush(hand, out var usedCards2);

        cardUsed.AddRange(usedCards1.Union(usedCards2));

        usedCard = cardUsed;
        return straight && flush;
    }

    private static bool IsFourOfAKind(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCards)
    {
        var cardUsed = new List<ICard>();

        var valueCount = GetCardCount(hand);
        var posibleData = valueCount.Find(data => data.CardTypesIncluded.Count == 4);

        if (posibleData != null)
        {
            cardUsed.AddRange(posibleData.CardsIncluded);
            usedCards = cardUsed;
            return true;
        }

        usedCards = cardUsed;
        return false;
    }

    private static bool IsFullHouse(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCards)
    {
        var cardUsed = new List<ICard>();

        var tempHand = new List<ICard>(hand);

        var isOnePair = IsOnePair(tempHand, out var usedCards1);

        tempHand = tempHand.Except(usedCards1).ToList();
        var isThreeKind = IsThreeOfAKind(tempHand, out var usedCards2);

        cardUsed.AddRange(usedCards1);
        cardUsed.AddRange(usedCards2);

        usedCards = cardUsed;
        return isOnePair && isThreeKind;
    }

    private static bool IsFlush(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCards)
    {
        var cardUsed = new List<ICard>();

        var suit = hand.ElementAt(0).CardType;
        int count = 0;
        var result = false;

        foreach (var card in hand)
        {
            if (card.CardType == suit)
            {
                count++;
                cardUsed.Add(card);
                if (count == 5)
                {
                    result = true;
                    break;
                }
            }
            else
            {
                result = false;
                break;
            }
        }
        usedCards = cardUsed;
        return result;
    }

    private static bool IsStraight(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCards)
    {
        var cardUsed = new List<ICard>();

        int count = 0;
        int amount = hand.Count();

        for (int i = amount - 1; i > 0; i--)
        {
            var value = hand.ElementAt(i).CardPower - hand.ElementAt(i - 1).CardPower;
            if (value == 0)
            {
                continue;
            }
            if (value == 1)
            {
                cardUsed.Add(hand.ElementAt(i));

                if (count >= 4)
                {
                    usedCards = cardUsed;
                    return true;
                }
                count++;
            }
            else
            {
                cardUsed.Clear();
                count = 0;
            }
        }
        usedCards = cardUsed;
        return false;
    }

    private static bool IsThreeOfAKind(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCards)
    {
        var cardUsed = new List<ICard>();

        var cardCount = GetCardCount(hand);
        var posibleData = cardCount.Find(data => data.Amount == 3);

        if (posibleData != null)
        {
            cardUsed = posibleData.CardsIncluded;
        }

        usedCards = cardUsed;
        return posibleData != null;
    }

    private static bool IsTwoPair(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCards)
    {
        var cardUsed = new List<ICard>();
        var tempHand = new List<ICard>(hand);

        var hasPair1 = IsOnePair(tempHand, out var usedCard1);

        tempHand = tempHand.Except(usedCard1).ToList();

        var hasPair2 = IsOnePair(tempHand, out var usedCard2);

        cardUsed.AddRange(usedCard2);
        cardUsed.AddRange(usedCard1);

        usedCards = cardUsed;
        return hasPair1 && hasPair2;
    }

    private static bool IsOnePair(IEnumerable<ICard> hand, out IEnumerable<ICard> usedCards)
    {
        var cardUsed = new List<ICard>();

        var cardCount = GetCardCount(hand);
        var possibleData = cardCount.Find(data => data.Amount == 2);

        if (possibleData != null)
        {
            cardUsed = possibleData.CardsIncluded;
        }

        usedCards = cardUsed;
        return possibleData != null;
    }

    public enum HandRanking
    {
        None = 0,
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfKind = 8,
        StraightFlush = 9
    }

    private class CustomCardCountData
    {
        public int CardNumber;
        public int Amount;
        public List<ICard> CardsIncluded;
        public List<CardType> CardTypesIncluded;

        public CustomCardCountData(int cardNumber, int amount,
        List<ICard> cardsIncluded, List<CardType> cardTypesIncluded)
        {
            CardTypesIncluded = cardTypesIncluded;
            CardNumber = cardNumber;
            Amount = amount;
            CardsIncluded = cardsIncluded;
        }
    }
}

