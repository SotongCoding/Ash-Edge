using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using SotongStudio.AshEdge.Service.ContentCollection;
using VContainer;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public class PlayerCardVisualControl : CardVisualControl
    {
        private IBattleCard _currentHoldData;
        private readonly PlayerCardVisualView _view;
        protected override CardVisualView View => _view;

        private IBattleCardsHandlerEventCoordinator _cardEventCoordinator;
        protected override IContentLoaderService ContentLoader { get; set; }

        [Inject]
        private void Inject(IBattleCardsHandlerEventCoordinator cardEventCoordinator, IContentLoaderService contentLoader)
        {
            _cardEventCoordinator = cardEventCoordinator;
            ContentLoader = contentLoader;
        }
        public PlayerCardVisualControl(PlayerCardVisualView view)
        {
            _view = view;
        }

        public override void Setup(IBattleCard playerCard)
        {
            base.Setup(playerCard);
            _view.SetCardClickAction(OnCardClickedEvent);
            _currentHoldData = playerCard;

        }

        private void OnCardClickedEvent()
        {
            _cardEventCoordinator.OnPlayerCardSelected.Invoke(_currentHoldData);
        }
    }
}
