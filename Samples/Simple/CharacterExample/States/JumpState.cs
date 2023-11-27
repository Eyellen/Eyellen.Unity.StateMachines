using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class JumpState : BaseState
    {
        private float _stateEnterTime;

        private float _maxStateResidenceTime = 0.5f;

        public JumpState(CharacterController context) : base(context) { }

        public override bool CheckSwitchState(out State state)
        {
            if (!_context.IsGrounded())
            {
                state = State.Midair;
                return true;
            }

            if (_context.IsGrounded() && Time.time > _stateEnterTime + _maxStateResidenceTime)
            {
                state = State.Idle;
                return true;
            }

            state = default;
            return false;
        }

        public override void Enter()
        {
            _stateEnterTime = Time.time;

            _context.Rigidbody.AddForce(Vector3.up * _context.JumpStrength, ForceMode.VelocityChange);
        }
    }
}
