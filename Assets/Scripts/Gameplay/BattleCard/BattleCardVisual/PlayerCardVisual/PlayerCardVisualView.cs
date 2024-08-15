using System;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public class PlayerCardVisualView : CardVisualView
    {
        
        public void SetCardClickAction(Action onCardClickedEvent)
        {
            ClickButton.onClick.RemoveAllListeners();
            ClickButton.onClick.AddListener(onCardClickedEvent.Invoke);
        }
    }
}
