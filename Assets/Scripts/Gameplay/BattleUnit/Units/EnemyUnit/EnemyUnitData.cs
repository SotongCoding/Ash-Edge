using SotongStudio.AshEdge.Esential.Character.Attribute;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;


namespace SotongStudio.AshEdge.Gameplay.Unit
{
    public interface IEnemyUnitData
    {
        
    }
    public class EnemyUnitData : BaseBattleUnitData, IEnemyUnitData
    {
        public EnemyUnitData(IUnitAttribute unitAttribute, BattleUnitVisualData visualData) : base(unitAttribute, visualData)
        {
        }
    }
}
