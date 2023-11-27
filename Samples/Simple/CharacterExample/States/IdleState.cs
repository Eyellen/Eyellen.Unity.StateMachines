using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class IdleState : BaseState
    {
        public IdleState(CharacterController context) : base(context) { }

        public override bool CheckSwitchState(out State state)
        {
            if (_context.Input.IsJumpPressed)
            {
                state = State.Jump;
                return true;
            }

            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
            {
                state = State.Walk;
                return true;
            }

            state = default;
            return false;
        }

        public override void Enter()
        {
            _context.Rigidbody.velocity = new Vector3(0, _context.Rigidbody.velocity.y, 0);
        }
    }
}
