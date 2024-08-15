
namespace SotongStudio.AshEdge.Esential.Character.Attribute
{
    public class ModifiedCharacterAttribute : CharacterAttribute,
    IModifBasiclCharacterAttribute, IModifSubCharacterAttribute
    {
        public ModifiedCharacterAttribute(IUnitAttribute baseStat) : base(baseStat)
        {
        }
        
        #region Basic Attribute
        public void AddDefense(int value) => Defense += value;
        public void AddHealth(int value) => Health += value;
        public void AddPower(int value) => Power += value;
        #endregion

        #region Additional Attribute
        public void AddEvasionRate(int value) => EvasionRate += value;
        public void AddBlockRate(int value) => BlockRate += value;
        public void AddCriticalRate(int value) => CriticalRate += value;
        public void AddCriticalDamage(int value) => CriticalDamage += value;
        #endregion

    }
}
