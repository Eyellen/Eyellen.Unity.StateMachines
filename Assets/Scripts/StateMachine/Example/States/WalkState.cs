namespace StateMachines.Example
{
    public class WalkState : State
    {
        private PlayerStateMachine _context;

        public WalkState(PlayerStateMachine context)
        {
            _context = context;
        }

        public override void Update()
        {
            base.Update();

            _context.Rigidbody.velocity = _context.WalkSpeed * (_context.Transform.rotation * _context.Input.MovementVector);
        }
    }
}
