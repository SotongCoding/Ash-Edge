

using SotongStudio.AshEdge.Service.ContentCollection;
using VContainer;

namespace SotongStudio.AshEdge.Gameplay.CardMechanic.Visual
{
    public class DetermineCardVisualControl : CardVisualControl
    {
        private readonly DetermineVisualCardView _view;
        protected override CardVisualView View => _view;

        protected override IContentLoaderService ContentLoader { get; set; }

        [Inject]
        private void Inject(IContentLoaderService contentLoader)
        {
            ContentLoader = contentLoader;
        }

        public DetermineCardVisualControl(DetermineVisualCardView view)
        {
            _view = view;
        }
    }
}
