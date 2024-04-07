using System;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples
{
    public class JumpState : BaseState
    {
        private float _stateEnterTime;

        private float _maxStateResidenceTime = 0.5f;

        public Action JumpIsGroundedWindowEnded;

        public JumpState(CharacterStateMachine stateMachine, Character context) : base(stateMachine, context) { }

        public override void Update()
        {
            if (_context.IsGrounded() && Time.time > _stateEnterTime + _maxStateResidenceTime)
                JumpIsGroundedWindowEnded?.Invoke();
        }

        public override void OnEnter()
        {
            _stateEnterTime = Time.time;

            _context.Rigidbody.AddForce(Vector3.up * _context.JumpStrength, ForceMode.VelocityChange);
        }
    }
}
