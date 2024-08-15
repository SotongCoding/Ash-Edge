using System;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public class PlayedCardVisualView : CardVisualView
    {

        public void SetCardClickAction(Action onCardClickedEvent)
        {
            ClickButton.onClick.RemoveAllListeners();
            ClickButton.onClick.AddListener(onCardClickedEvent.Invoke);
        }

        public void ResetVisual()
        {
            CardNumber.text = "0";
            CardImage.enabled = false;
        }
        public void ShowVisualImage()
        {
            CardImage.enabled = true;
        }
    }
}
