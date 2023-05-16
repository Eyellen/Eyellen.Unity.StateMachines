using UnityEngine;

namespace StateMachines.SingleLevel.Example
{
    public class WalkState : State
    {
        private PlayerStateMachine _context;

        public WalkState(PlayerStateMachine context)
        {
            _context = context;
        }

        public override void Update()
        {
            base.Update();

            Vector3 movement = new Vector3(
                _context.WalkSpeed * _context.Input.MovementVector.x,
                _context.Rigidbody.velocity.y,
                _context.WalkSpeed * _context.Input.MovementVector.z);

            _context.Rigidbody.velocity = _context.Transform.rotation * movement;
        }
    }
}
