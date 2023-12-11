using Eyellen.Unity.StateMachines.Hierarchical;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
{
    public class GroundedState : PlayerState
    {
        public GroundedState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void InitializeSubState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) < 0.1)
                SetSubState(_states[typeof(IdleState)]);

            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                SetSubState(_states[typeof(WalkState)]);
        }

        protected override void CheckSwitchState()
        {
            if (!_context.IsGrounded())
                SwitchState(_states[typeof(MidairState)]);

            if (_context.Input.IsJumpPressed)
                SwitchState(_states[typeof(JumpState)]);
        }
    }
}
