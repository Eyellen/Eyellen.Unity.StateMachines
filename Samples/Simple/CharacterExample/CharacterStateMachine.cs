using Eyellen.Unity.StateMachines.Simple;
using System.Collections.Generic;

namespace Eyellen.Unity.StateMachines.Samples.Simple
{
    public class CharacterStateMachine : StateMachine<State, BaseState>
    {
        public CharacterStateMachine(State initialState, CharacterController context) : base(initialState, context) { }

        protected override Dictionary<State, BaseState> InitializeStates(params object[] baseStateConstructorParams)
        {
            CharacterController context = (CharacterController)baseStateConstructorParams[0];

            Dictionary<State, BaseState> states = new()
            {
                { State.Idle, new IdleState(context) },
                { State.Walk, new WalkState(context) },
                { State.Run, new RunState(context) },
                { State.Jump, new JumpState(context) },
                { State.Midair, new MidairState(context) },
            };

            return states;
        }
    }
}
