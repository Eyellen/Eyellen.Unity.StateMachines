using System;
using UnityEngine;

namespace Eyellen.Unity.StateMachines
{
    public abstract class State
    {
        public readonly StateMachine StateMachine;

        public event Action OnEnterCallback;

        public event Action OnExitCallback;

        public event Action UpdateCallback;

        public event Action LateUpdateCallback;

        public event Action FixedUpdateCallback;

        public event Action<Collision> OnCollisionEnterCallback;

        public event Action<Collision> OnCollisionExitCallback;

        public event Action<Collision> OnCollisionStayCallback;

        public event Action<Collider> OnTriggerEnterCallback;

        public event Action<Collider> OnTriggerExitCallback;

        public event Action<Collider> OnTriggerStayCallback;

        public State(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void OnEnter()
        {
            OnEnterCallback?.Invoke();
        }

        public virtual void OnExit()
        {
            OnExitCallback?.Invoke();
        }

        public virtual void Update()
        {
            UpdateCallback?.Invoke();
        }

        public virtual void LateUpdate()
        {
            LateUpdateCallback?.Invoke();
        }

        public virtual void FixedUpdate()
        {
            FixedUpdateCallback?.Invoke();
        }

        public virtual void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterCallback?.Invoke(collision);
        }

        public virtual void OnCollisionExit(Collision collision)
        {
            OnCollisionExitCallback?.Invoke(collision);
        }

        public virtual void OnCollisionStay(Collision collision)
        {
            OnCollisionStayCallback?.Invoke(collision);
        }

        public virtual void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterCallback?.Invoke(other);
        }

        public virtual void OnTriggerExit(Collider other)
        {
            OnTriggerExitCallback?.Invoke(other);
        }

        public virtual void OnTriggerStay(Collider other)
        {
            OnTriggerStayCallback?.Invoke(other);
        }
    }
}
