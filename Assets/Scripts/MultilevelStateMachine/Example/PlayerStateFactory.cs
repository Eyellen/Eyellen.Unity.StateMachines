namespace StateMachines.Multilevel.Example
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
            States[typeof(GroundedState)] = new GroundedState(stateMachine, stateFactory, _context);
            States[typeof(MidairState)] = new MidairState(stateMachine, stateFactory, _context);
            States[typeof(IdleState)] = new IdleState(stateMachine, stateFactory, _context);
            States[typeof(WalkState)] = new WalkState(stateMachine, stateFactory, _context);
        }
    }
}
