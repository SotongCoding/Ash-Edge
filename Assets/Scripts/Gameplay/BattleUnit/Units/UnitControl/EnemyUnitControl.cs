using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Esential.Party;
using SotongStudio.AshEdge.Esential.Unit.Enemy;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.Unit.Control
{
    public interface IEnemyUnitControl
    {

    }
    public class EnemyUnitControl : BattleUnitControl, IEnemyUnitControl
    {
        public EnemyUnitControl(BattleUnitView unitView) : base(unitView)
        {
            
        }        
    }
}
