using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class IdleState : BaseState
    {
        public IdleState(CharacterController context) : base(context) { }

        public override State CheckSwitchState()
        {
            if (_context.Input.IsJumpPressed)
                return State.Jump;

            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                return State.Walk;

            return default;
        }

        public override void Enter()
        {
            _context.Rigidbody.velocity = new Vector3(0, _context.Rigidbody.velocity.y, 0);
        }
    }
}
