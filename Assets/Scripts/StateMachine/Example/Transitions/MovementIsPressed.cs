namespace StateMachines.SingleLevel.Example
{
    public class MovementIsPressed : Transition
    {
        private PlayerStateMachine _context;

        public MovementIsPressed(StateMachine stateMachine, State from, State to)
            : base(stateMachine, from, to)
        {
            _context = (PlayerStateMachine)stateMachine;
        }

        public override bool CheckCondition()
        {
            return _context.Input.MovementVector.magnitude >= 0.1f;
        }
    }
}
