using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.GameData.Skill;
using SotongStudio.AshEdge.Gameplay.UI.CharacterStatus;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using SotongStudio.VContainer;

namespace SotongStudio.AshEdge.Gameplay.TurnManager.State.EnemyState
{
    public interface IExecuteEnemyProcess : IStateProcess
    {

    }
    [RegisterAs(typeof(IExecuteEnemyProcess))]
    public class ExecuteEnemyProcess : IExecuteEnemyProcess
    {
        private readonly IBattleUnitsHandler _unitHandler;
        private readonly ICharacterStatusInfoController _characterStatus;
        private MasterSkillData.SkillLogic _selectedSkill;

        public ExecuteEnemyProcess(IBattleUnitsHandler unitHandler,
                                   ICharacterStatusInfoController characterStatus)
        {
            _unitHandler = unitHandler;
            _characterStatus = characterStatus;
        }

        public UniTask RunAsync(CancellationToken cancellationToken)
        {
            GetAction();
            return ExecuteActionAsync(cancellationToken);
        }


        private void GetAction()
        {
            var skill = _unitHandler.CurrentCharacterUnit.UsedSkills[0];
            _selectedSkill = skill.Logic;
        }

        private async UniTask ExecuteActionAsync(CancellationToken cancellationToken)
        {
            var executeProces = _selectedSkill.Invoke(_unitHandler.CurrentEnemyUnit, _unitHandler, cancellationToken);
            await executeProces;

            _characterStatus.UpdateHealthBar();
        }
    }
}
