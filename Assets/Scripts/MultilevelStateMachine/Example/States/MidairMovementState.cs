using UnityEngine;

namespace StateMachines.Multilevel.Example
{
    public class MidairMovementState : PlayerState
    {
        public MidairMovementState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) < 0.1)
                SwitchState(_states[typeof(MidairIdleState)]);
        }

        protected override void Update()
        {
            _context.Rigidbody.AddForce(_context.Transform.rotation * _context.Input.MovementVector * _context.MidairMovementSpeed,
                ForceMode.Acceleration);
        }
    }
}
