using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class BattleUnitView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public UnityEvent ClickAction = new();
    public void SetAnimationControl(RuntimeAnimatorController animatorController)
    {
        _animator.runtimeAnimatorController = animatorController;
    }

    public UniTask PlayAnimationAsync(string clip, CancellationToken cancellationToken)
    {
        UnityEngine.Debug.Log($"Execute Animation : {this.name} | {clip}");
        _animator.Play(clip);
        return UniTask.Delay((int)_animator.GetCurrentAnimatorStateInfo(0).length * 1000, cancellationToken: cancellationToken);
    }
}
