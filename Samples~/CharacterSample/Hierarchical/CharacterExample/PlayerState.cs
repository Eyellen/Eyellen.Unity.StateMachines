using Eyellen.Unity.StateMachines.Hierarchical;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
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
