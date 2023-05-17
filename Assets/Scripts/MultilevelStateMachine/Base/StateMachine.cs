using System;

namespace StateMachines.Multilevel
{
    public abstract class StateMachine
    {
        private State _currentState;

        protected abstract StateFactory StateFactory { get; }

        public void SetState(State newState)
        {
            _currentState?.ExitStates();
            _currentState = newState;
            _currentState.EnterStates();
        }

        public void Initialize(Type initialState)
        {
            SetState(StateFactory.States[initialState]);
        }

        public void Update()
        {
            _currentState.UpdateStates();
        }
    }
}
