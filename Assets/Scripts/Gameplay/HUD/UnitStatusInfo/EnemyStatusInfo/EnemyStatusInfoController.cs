
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using SotongStudio.VContainer;
using VContainer;

namespace SotongStudio.AshEdge.Gameplay.UI.EnemyStatus
{
    public interface IEnemyStatusInfoController
    {
        void Setup();
        void UpdateHealthBar();
    }
    [RegisterAs(typeof(IEnemyStatusInfoController))]
    public class EnemyStatusInfoController : IEnemyStatusInfoController
    {
        private readonly EnemyStatusInfoView _view;
        private IBattleHandledUnits _battleUnits;

        public EnemyStatusInfoController(EnemyStatusInfoView view)
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
            var enemy = _battleUnits.CurrentEnemyUnit;
            var healthPercentage = (float) enemy.Attribute.Health / enemy.BaseAttribute.Health;
            _view.Setup("Enemy", healthPercentage);
        }

        public void UpdateHealthBar()
        {
            var enemy = _battleUnits.CurrentEnemyUnit;
            var healthPercentage = (float) enemy.Attribute.Health / enemy.BaseAttribute.Health;
            _view.UpdateHealthBar(healthPercentage);
        }
    }
}