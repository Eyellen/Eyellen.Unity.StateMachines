using Eyellen.Unity.StateMachines.Hierarchical;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
{
    public class IdleState : PlayerState
    {
        public IdleState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                SwitchState(_states[typeof(WalkState)]);
        }

        protected override void Enter()
        {
            _context.Rigidbody.velocity = new Vector3(0, _context.Rigidbody.velocity.y, 0);
        }
    }
}
