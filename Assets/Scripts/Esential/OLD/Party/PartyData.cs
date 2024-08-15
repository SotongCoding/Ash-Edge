using SotongStudio.AshEdge.ModelData.Unit.Status;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Esential.Party
{
    public class PartyData
    {
        public List<PartyUnitData> UnitDatas { get; set; }
        public PartyUnitData CurrentActiveUnit { get; set; }

        public PartyData(List<PartyUnitData> unitDatas)
        {
            UnitDatas = unitDatas;
        }

        public void SetActiveUnit(PartyUnitData activeUnit)
        {
            CurrentActiveUnit = activeUnit;
        }

        public void SetActiveUnit(uint index)
        {
            if (index < UnitDatas.Count)
            {
                CurrentActiveUnit = UnitDatas[(int)index];
            }
        }
    }

    [System.Serializable]
    public class PartyUnitData
    {
        public string UnitId;
        //TODO : Adjust when party data ready
        [UnityEngine.SerializeField] private UnitStatusData Status;
        [HideInInspector]
        public UnitStatusData ModifiedStatus;

        public IBaseAttribute BaseAttribute => Status;
        private readonly IBaseAttribute _growthAttribute;

        public UnitGeneralInfo GeneralInfo;

        public PartyUnitData(string unitId, UnitStatusData status)
        {
            UnitId = unitId;
            Status = status;
            ModifiedStatus = new(status.Health, status.Power, status.Defense);
        }

        public PartyUnitData(PartyUnitData unit, IBaseAttribute growthAttribute)
        {
            UnitId = unit.UnitId;
            Status = new(unit.Status);
            ModifiedStatus = new(unit.BaseAttribute.Health, unit.BaseAttribute.Power, unit.BaseAttribute.Defense);
            _growthAttribute = growthAttribute;

            GeneralInfo = unit.GeneralInfo;
        }
        public void AddGrowthStatus()
        {
            var health = UnityEngine.Random.Range(10, _growthAttribute.Health);
            var defense = UnityEngine.Random.Range(1, _growthAttribute.Defense);
            var power = UnityEngine.Random.Range(1, _growthAttribute.Power);

            ModifiedStatus.AddGrowth(health, power, defense);
            Status.AddGrowth(health, power, defense);
        }

        [System.Serializable]
        public struct UnitGeneralInfo
        {
            public string Name;
            public Sprite UnityPotraitIcon;
            public RuntimeAnimatorController animatorController;
        }
    }
}
