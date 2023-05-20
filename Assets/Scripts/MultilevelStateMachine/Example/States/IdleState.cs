using UnityEngine;

namespace StateMachines.Multilevel.Example
{
    public class IdleState : PlayerState
    {
        public IdleState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                SwitchState(_states[typeof(WalkState)]);
        }
    }
}
