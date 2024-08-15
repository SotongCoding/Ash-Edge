
namespace SotongStudio.AshEdge.Esential.Character.Attribute
{
    public interface IUnitAttribute : IBasicUnitAttribute, ISubUnitAttribute
    {

    }
    public class CharacterAttribute : IUnitAttribute
    {
        public CharacterAttribute(IUnitAttribute baseStat)
        {
            Power = baseStat.Power;
            Defense = baseStat.Defense;
            Health = baseStat.Health;

            EvasionRate = baseStat.EvasionRate;
            BlockRate = baseStat.BlockRate;
            CriticalRate = baseStat.CriticalRate;
            CriticalDamage = baseStat.CriticalDamage;

        }
        #region Basic Attribute
        public int Power { get; protected set; }
        public int Defense { get; protected set; }
        public int Health { get; protected set; }

        #endregion

        #region Additional Attribute
        public int EvasionRate { get; protected set; }
        public int BlockRate { get; protected set; }
        public int CriticalRate { get; protected set; }
        public int CriticalDamage { get; protected set; }

        #endregion
    }
}
