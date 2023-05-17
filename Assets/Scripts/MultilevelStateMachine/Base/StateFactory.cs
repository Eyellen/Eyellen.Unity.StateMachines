using System;
using System.Collections.Generic;

namespace StateMachines.Multilevel
{
    public abstract class StateFactory
    {
        public Dictionary<Type, State> States = new Dictionary<Type, State>();

        protected abstract void InitializeStates(StateMachine stateMachine, StateFactory stateFactory);
    }
}
