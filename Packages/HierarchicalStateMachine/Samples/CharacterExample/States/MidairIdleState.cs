using UnityEngine;

namespace Eyellen.HierarchicalStateMachine.Samples
{
    public class MidairIdleState : PlayerState
    {
        public MidairIdleState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                SwitchState(_states[typeof(MidairMovementState)]);
        }
    }
}
