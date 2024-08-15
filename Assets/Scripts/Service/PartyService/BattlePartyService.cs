using SotongStudio.AshEdge.Esential.Party;

namespace SotongStudio.AshEdge.Service.Party
{
    public class BattlePartyService
    {
        private PartyData _currentPartyData;
        private readonly TempPartyData _tempPartyData;

        public BattlePartyService(TempPartyData tempPartyData)
        {
            _tempPartyData = tempPartyData;
            SetPartyData(tempPartyData.GetPartyData());
        }

        public void ReCreateParty()
        {
            SetPartyData(_tempPartyData.GetPartyData());
        }

        public PartyData GetCurrentParty()
        {
            return _currentPartyData;
        }
        public void SetPartyData(PartyData currentPartyData)
        {
            _currentPartyData = currentPartyData;
            _currentPartyData.SetActiveUnit(0);
        }
        public bool TrySetCurrentActiveUnit(string unitId)
        {
            var data = _currentPartyData.UnitDatas.Find(x => x.UnitId == unitId);
            if (data.ModifiedStatus.Health <= 0)
            {
                return false;
            }
            _currentPartyData.SetActiveUnit(data);
            return true;
        }
    }
}
