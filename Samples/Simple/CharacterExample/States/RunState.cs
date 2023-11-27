using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class RunState : BaseState
    {
        public RunState(CharacterController context) : base(context) { }

        public override State CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) < 0.1)
                return State.Idle;

            if (!_context.Input.IsSprinting)
                return State.Walk;

            if (_context.Input.IsJumpPressed)
                return State.Jump;

            return default;
        }

        public override void FixedUpdate()
        {
            Vector3 movement = _context.Transform.rotation * _context.Input.MovementVector * _context.RunSpeed;

            _context.Rigidbody.velocity = new Vector3(movement.x, _context.Rigidbody.velocity.y, movement.z);
        }
    }
}
