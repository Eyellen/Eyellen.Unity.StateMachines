namespace StateMachines.Multilevel
{
    public abstract class StateMachine
    {
        private State _currentState;

        public void SetState(State newState)
        {
            _currentState?.ExitStates();
            _currentState = newState;
            _currentState.EnterStates();
        }

        /// <summary>
        /// Take initialState via "new StateFactory(this).States[typeof(<![CDATA[typeOfState]]>)]".
        /// Note that StateFactory is an abstract class so you need your own inherited implementation.
        /// </summary>
        public void Initialize(State initialState)
        {
            SetState(initialState);
        }

        public void Update()
        {
            _currentState.UpdateStates();
        }
    }
}
