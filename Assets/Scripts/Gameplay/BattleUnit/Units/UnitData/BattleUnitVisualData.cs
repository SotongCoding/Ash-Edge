using SotongStudio.AshEdge.GameData.Character;
using SotongStudio.AshEdge.GameData.Enemy;
using UnityEngine;

namespace SotongStudio.AshEdge.Gameplay.Unit
{
    public class BattleUnitVisualData
    {
        public RuntimeAnimatorController AnimatorController;
        public Sprite CharcterIcon { get; private set; }

        public BattleUnitVisualData(CharacterVisuaConfig visualConfig)
        {
            AnimatorController = visualConfig.AnimatorController;
            CharcterIcon = visualConfig.CharacterIcon;
        }
        public BattleUnitVisualData(EnemyVisualConfig visualConfig)
        {
            AnimatorController = visualConfig.AnimatorController;
            CharcterIcon = visualConfig.EnemyIcon;
        }

    }
}
