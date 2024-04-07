using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples
{
    public class WalkState : BaseState
    {
        public WalkState(CharacterStateMachine stateMachine, Character context) : base(stateMachine, context) { }

        public override void FixedUpdate()
        {
            Vector3 movement = _context.Transform.rotation * _context.Input.MovementVector * _context.WalkSpeed;

            _context.Rigidbody.velocity = new Vector3(movement.x, _context.Rigidbody.velocity.y, movement.z);
        }
    }
}
