using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using SotongStudio.VContainer;
using VContainer;

namespace SotongStudio.AshEdge.Gameplay.UI.CharacterStatus
{
    public interface ICharacterStatusInfoController
    {
        void Setup();
        void UpdateHealthBar();
    }
    [RegisterAs(typeof(ICharacterStatusInfoController))]
    public class CharacterStatusInfoController : ICharacterStatusInfoController
    {
        private readonly CharacterStatusInfoView _view;
        private IBattleHandledUnits _battleUnits;
        private CharacterUnit _currentUnit;

        public CharacterStatusInfoController(CharacterStatusInfoView view)
        {
            _view = view;
        }

        [Inject]
        private void Inject(IBattleHandledUnits battleUnits)
        {
            _battleUnits = battleUnits;
        }

        public void Setup()
        {
            _currentUnit = _battleUnits.CurrentCharacterUnit;
            _view.Setup(_currentUnit);
        }

        public void UpdateHealthBar()
        {
            var baseHealth = _currentUnit.BaseAttribute.Health;
            var currentHealth = _currentUnit.Attribute.Health;
            _view.UpdateHealthBar(baseHealth, currentHealth);
        }
    }
}
