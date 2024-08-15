using System.Threading;
using Cysharp.Threading.Tasks;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State
{
    public interface IStateProcess
    {
        UniTask RunAsync(CancellationToken cancellationToken);
    }
}
