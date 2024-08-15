
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Esential.Party;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;

namespace SotongStudio.AshEdge.Gameplay.Unit.Control
{
    public interface ICharacterUnitControl
    {

    }
    public class CharacterUnitControl : BattleUnitControl, ICharacterUnitControl
    {
        public CharacterUnitControl(BattleUnitView unitView) : base(unitView)
        {
        }
    }
}
