using SotongStudio.AshEdge.Esential.Character.Attribute;
using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.Unit.Control.UnitState;

namespace SotongStudio.AshEdge
{
    public class BaseBattleUnitData
    {
        public CharacterAttribute BaseAttribute { get; private set; }
        public ModifiedCharacterAttribute ModifiedAttribute { get; private set; }
        public BattleUnitVisualData VisualData { get; private set; }
        public BattleUnitState UnitState { get; private set; }

        public BaseBattleUnitData(IUnitAttribute unitAttribute, BattleUnitVisualData visualData)
        {
            BaseAttribute = new(unitAttribute);
            ModifiedAttribute = new(BaseAttribute);
            VisualData = visualData;

            UnitState = new(this);
        }
    }
}
