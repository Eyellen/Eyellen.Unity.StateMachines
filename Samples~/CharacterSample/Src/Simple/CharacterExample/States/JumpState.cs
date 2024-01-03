using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class JumpState : BaseState
    {
        private float _stateEnterTime;

        private float _maxStateResidenceTime = 0.5f;

        public JumpState(CharacterController context) : base(context) { }

        public override State CheckSwitchState()
        {
            if (!_context.IsGrounded())
                return State.Midair;

            if (_context.IsGrounded() && Time.time > _stateEnterTime + _maxStateResidenceTime)
                return State.Idle;

            return default;
        }

        public override void Enter()
        {
            _stateEnterTime = Time.time;

            _context.Rigidbody.AddForce(Vector3.up * _context.JumpStrength, ForceMode.VelocityChange);
        }
    }
}
