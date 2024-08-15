using SotongStudio.AshEdge.Esential.Party;

namespace SotongStudio.AshEdge.DungeonExplore.PartyInfo
{
    public abstract class PartyUnitInfoController
    {
        public abstract void SetPartyVisual(PartyUnitData unitData);
        public abstract void SetActive(bool isActive);
    }
}
