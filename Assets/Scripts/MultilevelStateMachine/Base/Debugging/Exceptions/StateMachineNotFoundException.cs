using System;

namespace StateMachines.Multilevel.Debugging
{
    public class StateMachineNotFoundException : Exception
    {
        public StateMachineNotFoundException()
            : base() { }

        public StateMachineNotFoundException(string message)
            : base(message) { }
    }
}
