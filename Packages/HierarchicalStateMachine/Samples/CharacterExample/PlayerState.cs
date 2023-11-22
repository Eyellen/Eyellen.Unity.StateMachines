namespace Eyellen.HierarchicalStateMachine.Samples
{
    public class PlayerState : State
    {
        protected PlayerController _context;

        public PlayerState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory)
        {
            _context = context;
        }
    }
}
