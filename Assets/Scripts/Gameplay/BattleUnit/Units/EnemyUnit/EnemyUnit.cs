using System.Collections;
using System.Collections.Generic;
using SotongStudio.AshEdge.Gameplay.Unit.Control;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.Unit
{
    public class EnemyUnit : BaseBattleUnit
    {
        public EnemyUnit(EnemyUnitData unitData, EnemyUnitControl unitControl) : base(unitData, unitControl)
        {
        }
    }
}
