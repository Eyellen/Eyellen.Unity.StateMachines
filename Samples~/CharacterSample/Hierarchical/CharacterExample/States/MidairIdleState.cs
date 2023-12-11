using Eyellen.Unity.StateMachines.Hierarchical;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
{
    public class MidairIdleState : PlayerState
    {
        public MidairIdleState(StateMachine stateMachine, StateFactory stateFactory, PlayerController context)
            : base(stateMachine, stateFactory, context) { }

        protected override void CheckSwitchState()
        {
            if (Mathf.Abs(_context.Input.MovementVector.magnitude) >= 0.1)
                SwitchState(_states[typeof(MidairMovementState)]);
        }
    }
}
