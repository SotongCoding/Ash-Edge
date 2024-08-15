using SotongStudio.AshEdge.Esential.Character.Attribute;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;

namespace SotongStudio.AshEdge.Gameplay.Unit
{
    public interface ICharacterUnitData
    {
        
    }
    public class CharacterUnitData : BaseBattleUnitData, ICharacterUnitData
    {
        public CharacterUnitData(IUnitAttribute unitAttribute, BattleUnitVisualData visualData) : base(unitAttribute, visualData)
        {

        }


    }
}
