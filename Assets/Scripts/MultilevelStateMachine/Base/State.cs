using System;
using System.Collections.Generic;

namespace StateMachines.Multilevel
{
    public abstract class State
    {
        private State _currentSuperState;
        private State _currentSubState;

        private StateMachine _stateMachine;
        private StateFactory _stateFactory;

        protected IReadOnlyDictionary<Type, State> _states => _stateFactory.States;

        public State(StateMachine stateMachine, StateFactory stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
        }

        /// <summary>
        /// This method should be used to switch states of the same hierarchy level.
        /// </summary>
        protected void SwitchState(State newState)
        {
            if (_currentSuperState == null)
            {
                _stateMachine.SetState(newState);
            }
            else
            {
                ExitStates();
                newState.EnterStates();
                _currentSuperState.SetSubState(newState);
            }
        }

        /// <summary>
        /// Use this only to set sub state in InitializeSubState method.
        /// </summary>
        protected void SetSubState(State newState)
        {
            _currentSubState = newState;
            newState._currentSuperState = this;
        }

        public void EnterStates()
        {
            InitializeSubState();

            Enter();

            _currentSubState?.EnterStates();
        }

        public void ExitStates()
        {
            _currentSubState?.ExitStates();

            Exit();
        }

        public void UpdateStates()
        {
            Update();

            CheckSwitchState();

            _currentSubState?.UpdateStates();
        }

        public void FixedUpdateStates()
        {
            FixedUpdate();

            _currentSubState?.FixedUpdate();
        }

        protected virtual void InitializeSubState() { }

        protected virtual void CheckSwitchState() { }

        protected virtual void Enter() { }

        protected virtual void Exit() { }

        protected virtual void Update() { }

        protected virtual void FixedUpdate() { }
    }
}
