namespace SotongStudio.AshEdge.Esential.Character.Attribute
{
    public interface IBasicUnitAttribute
    {
        int Power { get; }
        int Defense { get; }
        int Health { get; }
    }
    public interface IModifBasiclCharacterAttribute
    {
        void AddPower(int value);
        void AddDefense(int value);
        void AddHealth(int value);
    }
}
