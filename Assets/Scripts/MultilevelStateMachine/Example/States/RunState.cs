using UnityEngine;

namespace StateMachines.Multilevel.Example
{
    public class RunState : PlayerState
    {
        public RunState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) < 0.1)
                SwitchState(_states[typeof(IdleState)]);

            if (!_context.Input.IsSprinting)
                SwitchState(_states[typeof(WalkState)]);
        }

        protected override void Update()
        {
            Vector3 movement = new Vector3(
                _context.Input.MovementVector.x, _context.Rigidbody.velocity.y, _context.Input.MovementVector.z);

            _context.Rigidbody.velocity = _context.Transform.rotation * movement * _context.RunSpeed;
        }
    }
}
