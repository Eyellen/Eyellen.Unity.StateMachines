using System;

namespace Eyellen.Unity.StateMachines.Simple
{
    public class StateChangedEventArgs<TStateEnum> : EventArgs
        where TStateEnum : Enum
    {
        public TStateEnum PreviousState { get; private set; }

        public TStateEnum CurrentState { get; private set; }

        public State<TStateEnum> PreviousStateInstance { get; private set; }

        public State<TStateEnum> CurrentStateInstance { get; private set; }

        public StateChangedEventArgs(TStateEnum previousState, TStateEnum currentState,
            State<TStateEnum> previousStateInstance, State<TStateEnum> currentStateInstance)
        {
            PreviousState = previousState;
            CurrentState = currentState;
            PreviousStateInstance = previousStateInstance;
            CurrentStateInstance = currentStateInstance;
        }
    }
}
