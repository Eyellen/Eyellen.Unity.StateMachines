using System;
using System.Collections.Generic;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Simple
{
    public abstract class StateMachine<TStateEnum, TBaseState>
        where TStateEnum : Enum
        where TBaseState : State<TStateEnum>
    {
        private IReadOnlyDictionary<TStateEnum, TBaseState> _states;

        public TStateEnum CurrentState { get; private set; }

        public event Action<TStateEnum, TStateEnum> OnStateChanged;

        public StateMachine(TStateEnum initialState, params object[] baseStateContructorParams)
        {
            _states = InitializeStates(baseStateContructorParams);

            CurrentState = initialState;
            _states[initialState].Enter();
        }

        protected abstract Dictionary<TStateEnum, TBaseState> InitializeStates(params object[] baseStateConstructorParams);

        private void SwitchState(TStateEnum newState)
        {
            TStateEnum previousState = CurrentState;
            _states[CurrentState].Exit();
            CurrentState = newState;
            _states[CurrentState].Enter();

            OnStateChanged?.Invoke(previousState, CurrentState);
        }

        public void Update()
        {
            _states[CurrentState].Update();

            TStateEnum state = _states[CurrentState].CheckSwitchState();
            if (!EqualityComparer<TStateEnum>.Default.Equals(state, default))
                SwitchState(state);
        }

        public void LateUpdate() => _states[CurrentState].LateUpdate();

        public void FixedUpdate() => _states[CurrentState].FixedUpdate();

        public void OnCollisionEnter(Collision collision) => _states[CurrentState].OnCollisionEnter(collision);

        public void OnCollisionExit(Collision collision) => _states[CurrentState].OnCollisionExit(collision);

        public void OnCollisionStay(Collision collision) => _states[CurrentState].OnCollisionStay(collision);

        public void OnTriggerEnter(Collider other) => _states[CurrentState].OnTriggerEnter(other);

        public void OnTriggerExit(Collider other) => _states[CurrentState].OnTriggerExit(other);

        public void OnTriggerStay(Collider other) => _states[CurrentState].OnTriggerStay(other);
    }
}