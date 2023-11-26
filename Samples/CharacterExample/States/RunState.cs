using Eyellen.Unity.StateMachines.Hierarchical;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
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

        protected override void FixedUpdate()
        {
            Vector3 movement = _context.Transform.rotation * _context.Input.MovementVector * _context.RunSpeed;

            _context.Rigidbody.velocity = new Vector3(movement.x, _context.Rigidbody.velocity.y, movement.z);
        }
    }
}
