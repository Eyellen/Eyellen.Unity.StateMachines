using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class RunState : BaseState
    {
        public RunState(CharacterController context) : base(context) { }

        public override bool CheckSwitchState(out State state)
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) < 0.1)
            {
                state = State.Idle;
                return true;
            }

            if (!_context.Input.IsSprinting)
            {
                state = State.Walk;
                return true;
            }

            if (_context.Input.IsJumpPressed)
            {
                state = State.Jump;
                return true;
            }

            state = default;
            return false;
        }

        public override void FixedUpdate()
        {
            Vector3 movement = _context.Transform.rotation * _context.Input.MovementVector * _context.RunSpeed;

            _context.Rigidbody.velocity = new Vector3(movement.x, _context.Rigidbody.velocity.y, movement.z);
        }
    }
}
