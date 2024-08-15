using System.Collections.Generic;
using SotongStudio.AshEdge.Esential.Character.Attribute;
using SotongStudio.AshEdge.GameData.Card;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using SotongStudio.AshEdge.ModelData.Unit.Status;
using Unity.Burst;
using UnityEngine;

public static class DamageCalculator
{
    private static int CalculateDamage(IBaseAttribute dealerStat, IBaseAttribute recieverStat, int basePower)
    {
        int dealerPower = dealerStat.Power;

        int recieverDefense = recieverStat.Defense;

        var factor1 = Mathf.Clamp(Mathf.CeilToInt(dealerPower + (dealerPower * 0.1f) -
                                                (recieverDefense + (recieverDefense * 0.3f))),
                                                0, 999);

        return Mathf.CeilToInt(basePower * factor1 * 0.3f);
    }

    public static int CalculateDamage(IBaseAttribute dealerStat, IBaseAttribute recieverStat, HandRankLogic.HandRanking handRank, IEnumerable<IBattleCard> usedCard)
    {
        var basePower = 0;
        foreach (var card in usedCard)
        {
            basePower += card.CardPower;
        }

        basePower = Mathf.CeilToInt(basePower * (int)handRank * 0.7f);
        return CalculateDamage(dealerStat, recieverStat, basePower);
    }
    public static int CalculateDamage(IBaseAttribute dealerStat, IBaseAttribute recieverStat)
    {
        var basePower = dealerStat.Power * 3;
        basePower = Mathf.CeilToInt(basePower);
        return CalculateDamage(dealerStat, recieverStat, basePower);
    }

    public static int CalculateCharacterDamage(IUnitAttribute characterAttribute, IUnitAttribute enemyAttribute)
    {
        int dealerPower = characterAttribute.Power;
        int recieverDefense = enemyAttribute.Defense;

        var damage = Mathf.Clamp(Mathf.CeilToInt(dealerPower - recieverDefense), 0, 999);

        return damage; 
    }
}
