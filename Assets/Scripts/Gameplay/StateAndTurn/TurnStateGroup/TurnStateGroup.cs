using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State
{
    public abstract class TurnStateGroup : BaseStateGroup
    {
        public abstract StateType RunningTurn { get; }

    }
}
