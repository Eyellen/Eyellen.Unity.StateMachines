using System;

namespace Eyellen.Unity.StateMachines.Hierarchical.Debugging
{
    public class StateMachineNotFoundException : Exception
    {
        public StateMachineNotFoundException()
            : base() { }

        public StateMachineNotFoundException(string message)
            : base(message) { }
    }
}
