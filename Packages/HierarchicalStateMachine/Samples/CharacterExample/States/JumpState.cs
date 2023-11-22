using UnityEngine;

namespace Eyellen.HierarchicalStateMachine.Samples
{
    public class JumpState : PlayerState
    {
        public JumpState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (_context.Rigidbody.velocity.y <= 0 && _startTime + 0.1 < Time.time)
                SwitchState(_states[typeof(MidairState)]);
        }

        private float _startTime;

        protected override void Enter()
        {
            _startTime = Time.time;

            _context.Rigidbody.AddForce(Vector3.up * _context.JumpStrength, ForceMode.VelocityChange);
        }
    }
}
