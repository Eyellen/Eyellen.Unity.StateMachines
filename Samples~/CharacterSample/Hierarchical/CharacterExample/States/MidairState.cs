using Eyellen.Unity.StateMachines.Hierarchical;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
{
    public class MidairState : PlayerState
    {
        public MidairState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void InitializeSubState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) < 0.1)
                SetSubState(_states[typeof(MidairIdleState)]);

            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                SetSubState(_states[typeof(MidairMovementState)]);
        }

        protected override void CheckSwitchState()
        {
            if (_context.IsGrounded())
                SwitchState(_states[typeof(GroundedState)]);
        }
    }
}
