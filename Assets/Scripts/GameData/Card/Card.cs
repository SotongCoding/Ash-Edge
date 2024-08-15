using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Card
{
    public interface ICard
    {
        CardType CardType { get; }
        ushort CardPower { get; }
    }

    public enum CardType
    {
        Strike,
        Magic,
        Action,
        Ace
    }
}
