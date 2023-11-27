using Eyellen.Unity.StateMachines.Simple;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public abstract class BaseState : State<State>
    {
        protected CharacterController _context;

        public BaseState(CharacterController context)
        {
            _context = context;
        }
    }
}
