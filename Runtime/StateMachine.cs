using System;
using UnityEngine;

namespace Eyellen.Unity.StateMachines
{
    public abstract partial class StateMachine : State
    {
        public State CurrentState { get; private set; }

        public event Action<State, State> OnStateChanged;

        public StateMachine(StateMachine parentStateMachine = null) : base(parentStateMachine) { }

        public void SetInitialState(State initialState)
        {
            if (CurrentState == null)
                CurrentState = initialState;
        }

        private void SwitchState(State toState)
        {
            if (toState == CurrentState)
                return;

            State previousState = CurrentState;
            CurrentState.OnExit();
            CurrentState = toState;
            CurrentState.OnEnter();

            OnStateChanged?.Invoke(previousState, CurrentState);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            CurrentState.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
            CurrentState.OnExit();
        }

        public override void Update()
        {
            base.Update();
            CurrentState.Update();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
            CurrentState.LateUpdate();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            CurrentState.FixedUpdate();
        }

        public override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            CurrentState.OnCollisionEnter(collision);
        }

        public override void OnCollisionExit(Collision collision)
        {
            base.OnCollisionExit(collision);
            CurrentState.OnCollisionExit(collision);
        }

        public override void OnCollisionStay(Collision collision)
        {
            base.OnCollisionStay(collision);
            CurrentState.OnCollisionStay(collision);
        }

        public override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            CurrentState.OnTriggerEnter(other);
        }

        public override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            CurrentState.OnTriggerExit(other);
        }

        public override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
            CurrentState.OnTriggerStay(other);
        }
    }
}