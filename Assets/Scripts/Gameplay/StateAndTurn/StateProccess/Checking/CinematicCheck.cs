using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Gameplay.TurnManager.State;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State
{
    public interface ICinematicCheck : IStateProcess
    {

    }
    [RegisterAs(typeof(ICinematicCheck))]
    public class CinematicCheck : ICinematicCheck
    {
        public CinematicCheck()
        {
        }

        public UniTask RunAsync(CancellationToken cancellationToken)
        {
            Debug.Log("Check cinematic");
            return UniTask.CompletedTask;
        }
    }
}
