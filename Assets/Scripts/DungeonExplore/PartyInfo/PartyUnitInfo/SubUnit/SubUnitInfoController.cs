

using System;
using SotongStudio.AshEdge.Esential.Party;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace SotongStudio.AshEdge.DungeonExplore.PartyInfo
{
    public class SubUnitInfoController : PartyUnitInfoController, IDisposable
    {
        public string UnitId { get; private set; }
        private readonly SubUnitInfoView _view;

        public System.Action<string> OnClickEvent;

        public SubUnitInfoController(SubUnitInfoView view)
        {
            _view = view;
            _view.OnClickEvent.AddListener(SelectUnit);
        }

        public override void SetActive(bool isActive)
        {
            _view.SetActive(isActive);
        }

        public override void SetPartyVisual(PartyUnitData unitData)
        {
            UnitId = unitData.UnitId;

            _view.SetVisual(unitData);
            _view.SetHealth(unitData);
        }

        private void SelectUnit()
        {
            OnClickEvent.Invoke(UnitId);
        }

        public void Dispose()
        {
            _view.OnClickEvent.RemoveListener(SelectUnit);
        }
    }
}
