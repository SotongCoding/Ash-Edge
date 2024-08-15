using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State
{
    public interface IStateGroup
    {
        IEnumerable<IStateProcess> StateProceses { get; }
        UniTask RunStateAsync(CancellationToken cancellationToken);
    }
    public abstract class BaseStateGroup : IStateGroup
    {
        public abstract IEnumerable<IStateProcess> StateProceses { get; protected set; }

        public async UniTask RunStateAsync(CancellationToken cancellationToken)
        {
            foreach (var process in StateProceses)
            {
                await process.RunAsync(cancellationToken);
            }

            await UniTask.Delay(1000, cancellationToken: cancellationToken);
        }
    }
}
