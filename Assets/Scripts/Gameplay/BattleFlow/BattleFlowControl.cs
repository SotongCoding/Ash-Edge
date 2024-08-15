using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.AshEdge.Gameplay.CardMechanic;
using SotongStudio.AshEdge.Gameplay.TurnManager;
using SotongStudio.AshEdge.Gameplay.TurnManager.State;
using SotongStudio.AshEdge.Gameplay.UI.CharacterStatus;
using SotongStudio.AshEdge.Gameplay.UI.EnemyStatus;
using SotongStudio.AshEdge.Gameplay.UnitMechanic;
using SotongStudio.AshEdge.Gameplay.WaveManager;
using UnityEngine;
using VContainer;

namespace SotongStudio.AshEdge
{
    public class BattleFlowControl : MonoBehaviour
    {
        private IBattleCardsHandler _cardController;
        private IBattleUnitsHandler _unitHandler;
        private ITurnStateManager _stateManager;
        private IEnemyWaveManager _enemyWaveManager;

        private ICharacterStatusInfoController _characterStatus;
        private IEnemyStatusInfoController _enemyStatus;

        private IPlayerTurnState _playerTurnState;
        private IEnemyTurnState _enemyTurnState;
        private IBattleCheckState _battleCheckState;

        private CancellationTokenSource _cts = new();

        [Inject]
        private void Inject(IBattleCardsHandler cardController,
                            IBattleUnitsHandler unitHandler,

                            ICharacterStatusInfoController characterStatusInfo,
                            IEnemyStatusInfoController enemyStatus,

                            ITurnStateManager stateManager,
                            IEnemyWaveManager enemyWave,

                            IPlayerTurnState palyerState,
                            IEnemyTurnState enemyState,
                            IBattleCheckState checkState)
        {
            _cardController = cardController;
            _unitHandler = unitHandler;
            _enemyWaveManager = enemyWave;

            _characterStatus = characterStatusInfo;
            _enemyStatus = enemyStatus;

            _stateManager = stateManager;
            _playerTurnState = palyerState;
            _enemyTurnState = enemyState;
            _battleCheckState = checkState;

            Initialize();
        }

        private void Initialize()
        {
            _stateManager.OnChangeState.AddListener(ChangeStateProcess);
            _stateManager.OnRefreshTurn.AddListener(LoadNextEnemy);

            _enemyWaveManager.Initialize();

            _unitHandler.Initialize();
            _cardController.Initialize();

            _characterStatus.Setup();
            _enemyStatus.Setup();

            _stateManager.NextTurn();
        }

        private void ChangeStateProcess(StateType state)
        {
            ChangeStateProcessAsync(state, _cts.Token).Forget();
        }
        private async UniTaskVoid ChangeStateProcessAsync(StateType state, CancellationToken cancellationToken)
        {
            var runningState = state switch
            {
                StateType.CharacterState => _playerTurnState.RunStateAsync(cancellationToken),
                StateType.EnemyState => _enemyTurnState.RunStateAsync(cancellationToken),
                StateType.CheckingState => _battleCheckState.RunStateAsync(cancellationToken),

                _ => throw new System.InvalidOperationException($"Failed Execute State, no Handle for {state} Type"),
            };
            await runningState;
            _stateManager.NextTurn();
        }
        private void LoadNextEnemy()
        {
            Debug.Log("Load Next Enemie");
            var nextEnemy = _enemyWaveManager.LoadNextEnemy();
            _unitHandler.InitializeNextEnemy(nextEnemy);
            _enemyStatus.Setup();
        }

    }
}
