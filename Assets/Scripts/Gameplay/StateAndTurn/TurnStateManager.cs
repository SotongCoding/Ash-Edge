using System;
using System.Collections.Generic;
using SotongStudio.VContainer;
using UnityEngine.Events;

namespace SotongStudio.AshEdge.Gameplay.TurnManager
{
    public interface ITurnStateManager
    {
        StateType CurrentState { get; }
        StateType LastUnitTurn { get; }

        UnityEvent<StateType> OnChangeState { get; }
        UnityEvent OnRefreshTurn { get; }
        public UnityEvent<StateType, int> OnChangeUnitTurn { get; }

        void EndTurn();
        void NextTurn();
        void Refresh();

        public bool IsTurnOver { get; }
    }
    [RegisterAs(typeof(ITurnStateManager))]
    public class TurnStateManager : ITurnStateManager
    {
        public StateType CurrentState { get; private set; } = StateType.CharacterState;
        public StateType LastUnitTurn { get; private set; } = StateType.CharacterState;
        private int _currentStateCount = 0;
        private int _unitTurnCount = 0;

        public UnityEvent<StateType> OnChangeState { get; private set; } = new();
        public UnityEvent OnRefreshTurn { get; private set; } = new();
        public UnityEvent<StateType, int> OnChangeUnitTurn { get; private set; } = new();

        public bool IsTurnOver { get; private set; } = false;

        private Dictionary<int, StateType> _stateOrder = new()
        {
            {0,StateType.CharacterState},
            {1,StateType.CheckingState},
            {2,StateType.EnemyState},
            {3,StateType.CheckingState},
        };

        public void NextTurn()
        {
            var stateId = _currentStateCount % _stateOrder.Count;
            CurrentState = _stateOrder[stateId];

            if (IsTurnOver)
            {
                return;
            }

            switch (CurrentState)
            {
                case StateType.CharacterState:
                    LastUnitTurn = StateType.CharacterState;
                    OnChangeState.Invoke(CurrentState);
                    OnChangeUnitTurn.Invoke(LastUnitTurn, _unitTurnCount);
                    break;
                case StateType.EnemyState:
                    LastUnitTurn = StateType.EnemyState;
                    OnChangeState.Invoke(CurrentState);
                    OnChangeUnitTurn.Invoke(LastUnitTurn, _unitTurnCount);
                    break;
                case StateType.CheckingState:
                    OnChangeState.Invoke(CurrentState);
                    break;
            }
            _currentStateCount += 1;
        }

        public void Refresh()
        {
            _currentStateCount = -1;
            CurrentState = StateType.CharacterState;
            LastUnitTurn = StateType.CharacterState;

            OnRefreshTurn.Invoke();
        }

        public void EndTurn()
        {
            IsTurnOver = true;
        }
    }
    public enum StateType
    {
        CheckingState = 0,
        CharacterState = 1,
        EnemyState = 2,
    }
}
