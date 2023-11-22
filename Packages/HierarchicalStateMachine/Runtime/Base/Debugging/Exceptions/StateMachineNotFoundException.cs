using System;

namespace Eyellen.HierarchicalStateMachine.Debugging
{
    public class StateMachineNotFoundException : Exception
    {
        public StateMachineNotFoundException()
            : base() { }

        public StateMachineNotFoundException(string message)
            : base(message) { }
    }
}
