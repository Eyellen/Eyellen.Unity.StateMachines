using UnityEngine;

namespace StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State _currentState;

        private void Update()
        {
            _currentState.Update();
        }

        public void SetState(State state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        protected void Initialize(State initialState)
        {
            SetState(initialState);
        }
    }
}
