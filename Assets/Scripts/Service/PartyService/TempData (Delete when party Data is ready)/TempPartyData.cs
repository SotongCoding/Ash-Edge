using SotongStudio.AshEdge.Esential.Party;
using SotongStudio.AshEdge.ModelData.Unit.Status;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge
{
    [CreateAssetMenu(menuName = "Battle/Temp/Party Data")]
    public class TempPartyData : ScriptableObject
    {
        [SerializeField] private List<TempPartyDataModel> _partyUnits;

        public PartyData GetPartyData()
        {
            List<PartyUnitData> result = new();
            foreach (var item in _partyUnits)
            {
                result.Add(new(item.Unit, item.GrowthStatus.EachGrowthData));
            }
            return new PartyData(result);
        }

    }

    [System.Serializable]
    public struct TempPartyDataModel
    {
        public PartyUnitData Unit;
        public GrowthStatus GrowthStatus;
    }

    [System.Serializable]
    public struct GrowthStatus
    {
        public UnitStatusData EachGrowthData;
    }

}
