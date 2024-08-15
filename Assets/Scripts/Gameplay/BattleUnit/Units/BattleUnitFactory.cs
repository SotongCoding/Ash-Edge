using SotongStudio.AshEdge.GameData.Character;
using SotongStudio.AshEdge.GameData.Enemy;
using SotongStudio.AshEdge.Gameplay.Unit.Control;

namespace SotongStudio.AshEdge.Gameplay.Unit.Helper
{
    public static class BattleUnitFactory
    {
        public static CharacterUnit CreateCharacterUnit(MasterCharacterData characterMasterData, CharacterUnitControl charaterUnit)
        {
            var characterAttribute = characterMasterData.BaseStat;
            var visualData = new BattleUnitVisualData(characterMasterData.VisualConfig);
            var skillData = characterMasterData.InitialSkills;

            CharacterUnitData data = new(characterAttribute, visualData);
            CharacterUnit result = new(data, charaterUnit, skillData);

            return result;
        }

        public static EnemyUnit CreateEnemyUnit(MasterEnemyConfigData enemyConfigData, EnemyUnitControl enemyUnit)
        {
            var characterAttribute = enemyConfigData.BaseStat;
            var visualData = new BattleUnitVisualData(enemyConfigData.VisualConfig);

            EnemyUnitData data = new(characterAttribute, visualData);
            EnemyUnit result = new(data, enemyUnit);

            return result;
        }
    }
}
