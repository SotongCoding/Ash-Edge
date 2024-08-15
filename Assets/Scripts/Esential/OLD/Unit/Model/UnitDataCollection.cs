using SotongStudio.AshEdge.ModelData.Unit.Status;

namespace SotongStudio.AshEdge.Esential.Unit
{
    public class UnitDataCollection : IBaseAttribute
    {
        public int Health { private set; get; }

        public int Power { private set; get; }

        public int Defense { private set; get; }
    }
}
