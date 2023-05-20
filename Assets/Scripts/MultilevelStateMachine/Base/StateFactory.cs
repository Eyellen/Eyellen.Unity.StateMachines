using System;
using System.Collections.Generic;

namespace StateMachines.Multilevel
{
    public abstract class StateFactory
    {
        protected Dictionary<Type, State> _states = new Dictionary<Type, State>();

        public IReadOnlyDictionary<Type, State> States => _states;

        protected abstract void InitializeStates(StateMachine stateMachine, StateFactory stateFactory);
    }
}
