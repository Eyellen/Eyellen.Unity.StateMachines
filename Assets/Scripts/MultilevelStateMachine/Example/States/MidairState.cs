namespace StateMachines.Multilevel.Example
{
    public class MidairState : PlayerState
    {
        public MidairState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (_context.IsGrounded())
                SwitchState(_states[typeof(GroundedState)]);
        }
    }
}
