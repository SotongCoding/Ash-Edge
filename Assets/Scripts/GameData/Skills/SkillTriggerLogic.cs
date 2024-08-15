using System.Collections.Generic;
using SotongStudio.AshEdge.GameData.Card;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;

namespace SotongStudio.AshEdge.BaseData.Skill.TiggerLogic
{
    public abstract class SkillTriggerLogic
    {
        public abstract bool IsTriggerFulfilled(IEnumerable<IBattleCard> usedCards);
    }

    [System.Serializable]
    public class CardTypeTriggerLogic : SkillTriggerLogic
    {
        public CardType TypeCard;
        public ushort Amount;

        public override bool IsTriggerFulfilled(IEnumerable<IBattleCard> usedCards)
        {
            int currentCounter = 0;
            foreach (var card in usedCards)
            {
                if (card.CardType == TypeCard)
                {
                    ++currentCounter;
                }
                if (currentCounter >= Amount)
                {
                    return true;
                }
            }
            return false;
        }
    }

    [System.Serializable]
    public class TotalPowerTriggerLogic : SkillTriggerLogic
    {

        public ushort Amount;
        public bool AsMoreThan;

        public override bool IsTriggerFulfilled(IEnumerable<IBattleCard> usedCards)
        {
            int currentPower = 0;
            foreach (var card in usedCards)
            {
                currentPower += card.CardPower;
            }

            return AsMoreThan ? currentPower >= Amount : currentPower < Amount;
        }
    }

    [System.Serializable]
    public class CardRankTriggerLogic : SkillTriggerLogic
    {

        public HandRankLogic.HandRanking Rank;

        public override bool IsTriggerFulfilled(IEnumerable<IBattleCard> usedCards)
        {
            List<ICard> cards = new(usedCards);
            var determineResult = HandRankLogic.DetermineCards<IBattleCard>(cards);
            
            return determineResult.handRanking == Rank;
        }
    }
}
