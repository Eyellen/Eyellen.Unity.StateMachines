using Eyellen.Unity.StateMachines.Hierarchical;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
{
    public class PlayerStateFactory : StateFactory
    {
        private PlayerController _context;

        public PlayerStateFactory(StateMachine stateMachine, PlayerController context)
            : base()
        {
            _context = context;
            InitializeStates(stateMachine, this);
        }

        protected override void InitializeStates(StateMachine stateMachine, StateFactory stateFactory)
        {
            _states[typeof(GroundedState)] = new GroundedState(stateMachine, stateFactory, _context);
            _states[typeof(MidairState)] = new MidairState(stateMachine, stateFactory, _context);
            _states[typeof(JumpState)] = new JumpState(stateMachine, stateFactory, _context);
            _states[typeof(IdleState)] = new IdleState(stateMachine, stateFactory, _context);
            _states[typeof(WalkState)] = new WalkState(stateMachine, stateFactory, _context);
            _states[typeof(RunState)] = new RunState(stateMachine, stateFactory, _context);
            _states[typeof(MidairIdleState)] = new MidairIdleState(stateMachine, stateFactory, _context);
            _states[typeof(MidairMovementState)] = new MidairMovementState(stateMachine, stateFactory, _context);
        }
    }
}
