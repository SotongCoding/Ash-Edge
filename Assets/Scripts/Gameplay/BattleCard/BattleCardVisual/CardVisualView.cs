using SotongStudio.AshEdge.GameData.Card;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public abstract class CardVisualView : MonoBehaviour
    {
        [SerializeField] protected TMP_Text CardNumber;
        [SerializeField] protected Image CardImage;
        [SerializeField] protected Image NumberBgImage;
        [SerializeField] protected Button ClickButton;

        public void Setup(IBattleCard cardData, CardVisualData visualData)
        {
            CardNumber.text = cardData.CardPower.ToString();

            CardImage.sprite = visualData.CardIcon;

        }
        
    }
}
