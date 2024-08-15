using SotongStudio.AshEdge.GameData.Enemy;
using SotongStudio.AshEdge.Gameplay.Unit;
using SotongStudio.AshEdge.Gameplay.Unit.Control;
using SotongStudio.AshEdge.Gameplay.Unit.Helper;
using SotongStudio.AshEdge.Gameplay.WaveManager;
using SotongStudio.AshEdge.Service.ContentCollection;
using SotongStudio.AshEdge.Shared.GameData.Battle.Provider;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.UnitMechanic
{
    public interface IBattleHandledUnits
    {
        CharacterUnit CurrentCharacterUnit { get; }
        EnemyUnit CurrentEnemyUnit { get; }

        void InitializeNextEnemy(MasterEnemyConfigData enemyConfigData);
    }
    public interface IBattleUnitsHandler : IBattleHandledUnits
    {
        void Initialize();
    }

    [RegisterAs(typeof(IBattleUnitsHandler), typeof(IBattleHandledUnits))]
    public class BattleUnitsHandler : IBattleUnitsHandler
    {
        private readonly CharacterUnitControl _charaterUnitControl;
        private readonly EnemyUnitControl _enemyUnitControl;
        private readonly IContentLoaderService _contentLoader;
        private readonly IEnemyWaveManager _waveManager;
        private readonly IBattleDataProvider _battleProvider;

        public CharacterUnit CurrentCharacterUnit { get; private set; }
        public EnemyUnit CurrentEnemyUnit { get; private set; }

        public BattleUnitsHandler(
            CharacterUnitControl charaterUnitControl,
            EnemyUnitControl enemyUnitControl,
            IContentLoaderService contentLoader,
            IEnemyWaveManager waveManager,
            IBattleDataProvider battleProvider)
        {
            _charaterUnitControl = charaterUnitControl;
            _enemyUnitControl = enemyUnitControl;
            _contentLoader = contentLoader;
            _waveManager = waveManager;
            _battleProvider = battleProvider;
        }

        public void Initialize()
        {
            var playedCharacterId = _battleProvider.GetPlayedCharacterId();
            var character = _contentLoader.GetCharaterMasterData(playedCharacterId);
            var enemy = _waveManager.LoadNextEnemy(); //This Should Load first Enemy

            CurrentCharacterUnit = BattleUnitFactory.CreateCharacterUnit(character, _charaterUnitControl);
            CurrentEnemyUnit = BattleUnitFactory.CreateEnemyUnit(enemy, _enemyUnitControl);

            CurrentCharacterUnit.Initialize();
            CurrentEnemyUnit.Initialize();
        }

        public void InitializeNextEnemy(MasterEnemyConfigData enemyConfigData)
        {
            CurrentEnemyUnit = BattleUnitFactory.CreateEnemyUnit(enemyConfigData, _enemyUnitControl);
            CurrentEnemyUnit.Initialize();

        }
    }
}
