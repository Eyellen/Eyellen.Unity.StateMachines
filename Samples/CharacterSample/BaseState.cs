namespace Eyellen.Unity.StateMachines.Samples
{
    public abstract class BaseState : State
    {
        protected Character _context;

        public BaseState(CharacterStateMachine stateMachine, Character context) : base(stateMachine)
        {
            _context = context;
        }
    }
}
