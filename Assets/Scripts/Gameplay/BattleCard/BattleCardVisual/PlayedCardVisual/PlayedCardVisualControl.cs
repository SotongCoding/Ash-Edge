using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using SotongStudio.AshEdge.Service.ContentCollection;
using VContainer;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public class PlayedCardVisualControl : CardVisualControl
    {
        private readonly PlayedCardVisualView _view;
        protected override CardVisualView View => _view;

        private IBattleCard _currentHoldData;
        private IBattleCardsHandlerEventCoordinator _cardEventCoordinator;
        protected override IContentLoaderService ContentLoader { get; set; }


        [Inject]
        private void Inject(IBattleCardsHandlerEventCoordinator cardEventCoordinator, IContentLoaderService contentLoader)
        {
            _cardEventCoordinator = cardEventCoordinator;
            ContentLoader = contentLoader;

            _view.ResetVisual();
        }

        public PlayedCardVisualControl(PlayedCardVisualView view)
        {
            _view = view;
        }
        public void ResetCardVisual()
        {
            _view.ResetVisual();
        }

        public override void Setup(IBattleCard playedCard)
        {
            base.Setup(playedCard);

            _view.SetCardClickAction(OnCardClickedEvent);
            _view.ShowVisualImage();

            _currentHoldData = playedCard;

        }

        private void OnCardClickedEvent()
        {
            _cardEventCoordinator.OnPlayedCardSelected.Invoke(_currentHoldData);

        }
    }
}
