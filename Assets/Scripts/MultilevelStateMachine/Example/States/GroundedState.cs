using System;

namespace StateMachines.Multilevel.Example
{
    public class GroundedState : PlayerState
    {
        public GroundedState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void InitializeSubState()
        {
            if (Math.Abs(_context.Input.MovementVector.magnitude) < 0.1)
                SetSubState(_states[typeof(IdleState)]);

            if (Math.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                SetSubState(_states[typeof(WalkState)]);
        }

        protected override void CheckSwitchState()
        {
            if (!_context.IsGrounded())
                SwitchState(_states[typeof(MidairState)]);
        }
    }
}
