namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class MidairState : BaseState
    {
        public MidairState(CharacterController context) : base(context) { }

        public override State CheckSwitchState()
        {
            if (_context.IsGrounded())
                return State.Idle;

            return default;
        }
    }
}
