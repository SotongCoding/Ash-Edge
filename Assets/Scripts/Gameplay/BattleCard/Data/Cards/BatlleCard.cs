using SotongStudio.AshEdge.GameData.Card;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Data
{
    public interface IBattleCard : ICard
    {

    }

    public class BattleCard : IBattleCard
    {
        public CardType CardType { get; private set; }
        public ushort CardPower { get; private set; }

        public BattleCard()
        {

        }

        public BattleCard(ushort cardPower, CardType cardType)
        {
            CardPower = cardPower;
            CardType = cardType;
        }
    }

    [System.Serializable]
    public class TestBattleCard
    {
        public CardType CardType;
        public ushort CardPower;
        public string MasterCardId;
    }
}
