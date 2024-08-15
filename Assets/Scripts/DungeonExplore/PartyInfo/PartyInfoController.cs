using System;
using System.Collections.Generic;
using System.Linq;
using SotongStudio.AshEdge.DungeonExplore.PartyInfo;
using SotongStudio.AshEdge.Service.Party;
using UnityEngine;

namespace SotongStudio.AshEdge
{
    public class PartyInfoController
    {
        private readonly MainUnitIfoController _mainUnitInfo;
        private readonly IReadOnlyList<SubUnitInfoController> _subUnitInfos;

        private readonly BattlePartyService _battleParty;

        public PartyInfoController(MainUnitIfoController mainUnitInfo, IReadOnlyList<SubUnitInfoController> subUnitInfos, BattlePartyService battleParty)
        {
            _mainUnitInfo = mainUnitInfo;
            _subUnitInfos = subUnitInfos;
            _battleParty = battleParty;

            foreach (var item in _subUnitInfos)
            {
                item.OnClickEvent = ReactOnClick;
            }

            UpdatePartyData();
        }

        public void UpdatePartyData()
        {
            var currentActiveUnit = _battleParty.GetCurrentParty().CurrentActiveUnit;
            var othersPartyMembers = _battleParty.GetCurrentParty().UnitDatas.Except(new[] { currentActiveUnit });

            Debug.Log($"Current Active party :  {currentActiveUnit.UnitId}");

            _mainUnitInfo.SetPartyVisual(currentActiveUnit);
            foreach (var partyInfo in _subUnitInfos)
            {
                partyInfo.SetActive(false);
            }

            int index = 0;
            foreach (var data in othersPartyMembers)
            {
                _subUnitInfos[index].SetPartyVisual(data);
                _subUnitInfos[index].SetActive(true);
                index++;
            }
        }

        public void ReactOnClick(string unitId)
        {
            Debug.Log($"Click Select Party {unitId}");
            var possible = _battleParty.TrySetCurrentActiveUnit(unitId);
            if (possible)
            {
                UpdatePartyData();
            }
        }
    }
}
