using System;

namespace Eyellen.Unity.StateMachines
{
    public abstract partial class StateMachine : State
    {
        protected class Transition
        {
            public StateMachine StateMachine { get; private set; }

            public State ToState { get; private set; }

            private Func<bool> _condition;

            public Transition(State to, Func<bool> condition = null)
            {
                if (to == null)
                    throw new NullReferenceException($"{nameof(to)} is null.");

                if (to.StateMachine == null)
                    throw new ArgumentException($"Given {nameof(to)} state is not located in any state machine.\n" +
                        $"To create a transition to a state it must be in a state machine.");

                StateMachine = to.StateMachine;
                ToState = to;
                _condition = condition;
            }

            public bool IsSatisfied()
            {
                return _condition == null ? true : _condition();
            }

            public void Perform()
            {
                StateMachine.SwitchState(ToState);
            }

            public void PerformIfSatisfied()
            {
                if (!IsSatisfied())
                    return;

                Perform();
            }
        }
    }
}
