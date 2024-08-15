using UnityEngine;

namespace SotongStudio.AshEdge.GameData.Card
{
    [CreateAssetMenu(menuName = "Game Data/Master Card Data", fileName ="CRD-XXX-Name")]
    public class MasterCardData : ContentCollectionItem
    {
        public override string MasterId => CardType.ToString();
        public CardType CardType;

        public CardVisualData VisualData;
        public CardGeneralData GeneralData;

    }

    [System.Serializable]
    public class CardVisualData
    {
        public Sprite CardIcon;
    }

    [System.Serializable]
    public class CardGeneralData
    {
        public string CardName;
        public string CardDescription;
    }
}
