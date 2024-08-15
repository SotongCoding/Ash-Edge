using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace SotongStudio.AshEdge
{
    public class DungeonNodeObjectItemView : MonoBehaviour
    {

        [SerializeField]
        private UILineRenderer _lineConnector;
        [SerializeField] private Button _clickButton;
        [SerializeField] private Image _nodeIcon;
        public UILineRenderer LineConnector => _lineConnector;
        public UnityEvent OnClickNode { private set; get; } = new();

        private void Awake()
        {
            _clickButton.onClick.AddListener(OnClickNode.Invoke);
        }

        public void SetupObject(Vector2 nodePosition)
        {
            ((RectTransform)transform).anchoredPosition = nodePosition;
        }

        public void ClearConneectionLine()
        {

        }

        internal void SetNodeIcon(Sprite nodeSpriteIcon)
        {
            _nodeIcon.sprite = nodeSpriteIcon;
        }
    }
}
