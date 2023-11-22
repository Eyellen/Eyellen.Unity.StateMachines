using UnityEngine;

namespace Eyellen.HierarchicalStateMachine.Samples
{
    public class WalkState : PlayerState
    {
        public WalkState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) < 0.1)
                SwitchState(_states[typeof(IdleState)]);

            if (_context.Input.IsSprinting)
                SwitchState(_states[typeof(RunState)]);
        }

        protected override void FixedUpdate()
        {
            Vector3 movement = _context.Transform.rotation * _context.Input.MovementVector * _context.WalkSpeed;

            _context.Rigidbody.velocity = new Vector3(movement.x, _context.Rigidbody.velocity.y, movement.z);
        }
    }
}
