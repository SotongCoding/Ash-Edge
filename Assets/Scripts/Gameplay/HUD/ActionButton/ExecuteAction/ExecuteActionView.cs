using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio.AshEdge.Gameplay.UI.ActionControl
{
    public class ExecuteActionView : MonoBehaviour
    {
        public UnityEvent OnExecuteEvent { set; get; } = new();
        [SerializeField] private Button _executeButton;

        private void Awake()
        {
            _executeButton.onClick.AddListener(OnExecuteEvent.Invoke);
        }
        private void OnDestroy()
        {
            OnExecuteEvent.RemoveListener(OnExecuteEvent.Invoke);
        }

        public void SetInteractable(bool interactable)
        {
            _executeButton.interactable = interactable;
        }
    }
}
