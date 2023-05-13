namespace StateMachines
{
    public abstract class Transition
    {
        private StateMachine _stateMachine;
        private State _fromState;
        private State _toState;

        public Transition(StateMachine stateMachine, State from, State to)
        {
            _stateMachine = stateMachine;
            _fromState = from;
            _toState = to;
            from.AddTransition(this);
        }

        public abstract bool CheckCondition();

        public void Update()
        {
            if (!CheckCondition()) return;

            _stateMachine.SetState(_toState);
        }
    }
}
