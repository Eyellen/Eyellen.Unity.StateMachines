using System;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Simple
{
    public abstract class StateMachineBehaviour<TStateMachine, TStateEnum, TBaseState> : MonoBehaviour
        where TStateMachine : StateMachine<TStateEnum, TBaseState>, new()
        where TStateEnum : Enum
        where TBaseState : State<TStateEnum>
    {
        private TStateMachine _stateMachine;

        public TStateEnum CurrentState => _stateMachine.CurrentState;

        public event Action<TStateEnum, TStateEnum> OnStateChanged;

        protected virtual void Awake()
        {
            _stateMachine = new TStateMachine();
            _stateMachine.OnStateChanged += OnStateChanged;
        }

        protected virtual void Start() { }

        protected virtual void Update() => _stateMachine.Update();

        protected virtual void LateUpdate() => _stateMachine.LateUpdate();

        protected virtual void FixedUpdate() => _stateMachine.FixedUpdate();

        protected virtual void OnCollisionEnter(Collision collision) => _stateMachine.OnCollisionEnter(collision);

        protected virtual void OnCollisionExit(Collision collision) => _stateMachine.OnCollisionExit(collision);

        protected virtual void OnCollisionStay(Collision collision) => _stateMachine.OnCollisionStay(collision);

        protected virtual void OnTriggerEnter(Collider other) => _stateMachine.OnTriggerEnter(other);

        protected virtual void OnTriggerExit(Collider other) => _stateMachine.OnTriggerExit(other);

        protected virtual void OnTriggerStay(Collider other) => _stateMachine.OnTriggerStay(other);
    }
}
