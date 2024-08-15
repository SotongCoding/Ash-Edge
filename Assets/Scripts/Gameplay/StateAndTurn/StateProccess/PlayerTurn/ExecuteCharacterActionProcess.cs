using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.GameData.Skill;
using SotongStudio.AshEdge.Gameplay.CardMechanic;
using SotongStudio.AshEdge.Gameplay.CardMechanic.Data;
using SotongStudio.AshEdge.Gameplay.UI.EnemyStatus;
using SotongStudio.AshEdge.Gameplay.UI.SkillInfo;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State.PlayerState
{
    public interface IExecuteCharacterActionProcess : IStateProcess
    {

    }
    [RegisterAs(typeof(IExecuteCharacterActionProcess))]
    public class ExecuteCharacterActionProcess : IExecuteCharacterActionProcess
    {
        private readonly IBattleCardsHandlerEventCoordinator _cardEvent;
        private readonly IBattleUnitsHandler _unitHandler;
        private readonly IBattleSkillInfoController _skillInfo;
        private readonly IEnemyStatusInfoController _enemyStatus;
        private MasterSkillData.SkillLogic _selectedCharacterSkillLogic;

        public ExecuteCharacterActionProcess(IBattleCardsHandlerEventCoordinator cardEventHandler,
                                      IBattleUnitsHandler unitHandler,
                                      IBattleSkillInfoController skillInfoController,
                                      
                                      IEnemyStatusInfoController enemyStatus)
        {
            _cardEvent = cardEventHandler;
            _unitHandler = unitHandler;
            _skillInfo = skillInfoController;

            _enemyStatus = enemyStatus;

            Initialize();
        }

        public UniTask RunAsync(CancellationToken cancellationToken)
        {
            return DoPlayerActionAsync(cancellationToken);
        }

        private void Initialize()
        {
            _cardEvent.OnCheckSelectedCards.AddListener(ChcekUnitSkillAvability);
        }
        private void ChcekUnitSkillAvability(IEnumerable<IBattleCard> cards)
        {
            var skill = _unitHandler.CurrentCharacterUnit.UsedSkills[0];
            _skillInfo.SetSkillInfo(skill.GeneralInfo, skill.SkillIcon);
            _selectedCharacterSkillLogic = skill.Logic;
        }

        private async UniTask DoPlayerActionAsync(CancellationToken cancellationToken)
        {
            
            var actionProcessAsync = _selectedCharacterSkillLogic?.Invoke(_unitHandler.CurrentCharacterUnit, _unitHandler, cancellationToken);

            await actionProcessAsync.Value;
            _selectedCharacterSkillLogic = null;

            _enemyStatus.UpdateHealthBar();
        }
    }
}
