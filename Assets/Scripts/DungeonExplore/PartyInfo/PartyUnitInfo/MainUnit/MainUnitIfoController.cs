
using SotongStudio.AshEdge.Esential.Party;

namespace SotongStudio.AshEdge.DungeonExplore.PartyInfo
{
    public class MainUnitIfoController : PartyUnitInfoController
    {
        private readonly MainUnitInfoView _view;
        public string UnitId { get; private set;}
        public MainUnitIfoController(MainUnitInfoView view)
        {
            _view = view;
        }

        public override void SetActive(bool isActive)
        {
            return;
        }

        public override void SetPartyVisual(PartyUnitData unitData)
        {
            UnitId = unitData.UnitId;
            
            _view.SetVisual(unitData);
            _view.SetHealth(unitData);
        }
    }
}
