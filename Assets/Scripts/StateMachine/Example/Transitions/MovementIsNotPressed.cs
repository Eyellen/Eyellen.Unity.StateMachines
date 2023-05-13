namespace StateMachines.Example
{
    public class MovementIsNotPressed : Transition
    {
        private PlayerStateMachine _context;

        public MovementIsNotPressed(StateMachine stateMachine, State from, State to)
            : base(stateMachine, from, to)
        {
            _context = (PlayerStateMachine)stateMachine;
        }

        public override bool CheckCondition()
        {
            return _context.Input.MovementVector.magnitude < 0.1f;
        }
    }
}
