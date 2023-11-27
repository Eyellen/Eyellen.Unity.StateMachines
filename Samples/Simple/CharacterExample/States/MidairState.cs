namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class MidairState : BaseState
    {
        public MidairState(CharacterController context) : base(context) { }

        public override bool CheckSwitchState(out State state)
        {
            if (_context.IsGrounded())
            {
                state = State.Idle;
                return true;
            }

            state = default;
            return false;
        }
    }
}
