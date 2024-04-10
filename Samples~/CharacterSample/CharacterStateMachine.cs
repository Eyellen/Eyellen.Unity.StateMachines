using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples
{
    public class CharacterStateMachine : StateMachine
    {
        public CharacterStateMachine(Character context)
        {
            IdleState idleState = new IdleState(this, context);
            JumpState jumpState = new JumpState(this, context);
            MidairState midairState = new MidairState(this, context);
            RunState runState = new RunState(this, context);
            WalkState walkState = new WalkState(this, context);

            idleState.UpdateCallback += new Transition(jumpState, () => context.Input.IsJumpPressed).PerformIfSatisfied;
            idleState.UpdateCallback += new Transition(walkState, () => Mathf.Abs(context.Input.MovementVector.magnitude) >= 0.1).PerformIfSatisfied;

            jumpState.UpdateCallback += new Transition(midairState, () => !context.IsGrounded()).PerformIfSatisfied;
            jumpState.JumpIsGroundedWindowEnded += new Transition(idleState).PerformIfSatisfied;

            midairState.UpdateCallback += new Transition(idleState, () => context.IsGrounded()).PerformIfSatisfied;

            runState.UpdateCallback += new Transition(idleState, () => Mathf.Abs(context.Input.MovementVector.magnitude) < 0.1).PerformIfSatisfied;
            runState.UpdateCallback += new Transition(walkState, () => !context.Input.IsSprinting).PerformIfSatisfied;
            runState.UpdateCallback += new Transition(jumpState, () => context.Input.IsJumpPressed).PerformIfSatisfied;

            walkState.UpdateCallback += new Transition(idleState, () => Mathf.Abs(context.Input.MovementVector.magnitude) < 0.1).PerformIfSatisfied;
            walkState.UpdateCallback += new Transition(runState, () => context.Input.IsSprinting).PerformIfSatisfied;
            walkState.UpdateCallback += new Transition(jumpState, () => context.Input.IsJumpPressed).PerformIfSatisfied;

            SetInitialState(idleState);
        }
    }
}
