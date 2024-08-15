using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.Unit.Control.UnitState
{
    public interface IBattleUnitState
    {
        bool IsDeath { get; }
    }
    public class BattleUnitState : IBattleUnitState
    {
        #region Data Reference
        private readonly BaseBattleUnitData _unitData;
        #endregion

        #region State
        public bool IsDeath => _unitData.ModifiedAttribute.Health <= 0;
        #endregion
        
        public BattleUnitState(BaseBattleUnitData unitData)
        {
            _unitData = unitData;
        }



    }
}
