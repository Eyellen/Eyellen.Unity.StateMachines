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
