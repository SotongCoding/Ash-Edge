using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using SotongStudio.AshEdge.Service.ContentCollection;
using VContainer;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public abstract class CardVisualControl
    {
        protected abstract IContentLoaderService ContentLoader { get; set; }
        protected abstract CardVisualView View { get; }


        public virtual void Setup(IBattleCard cardData)
        {
            var content = ContentLoader.GetMasterCardData(cardData.CardType.ToString());
            View.Setup(cardData, content.VisualData);
        }
    }
}
