using System;
using UnityEngine;

namespace Eyellen.Unity.StateMachines.Simple
{
    public abstract class State<TStateEnum>
        where TStateEnum : Enum
    {
        public abstract bool CheckSwitchState(out TStateEnum state);

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }

        public virtual void LateUpdate() { }

        public virtual void FixedUpdate() { }

        public virtual void OnCollisionEnter(Collision collision) { }

        public virtual void OnCollisionExit(Collision collision) { }

        public virtual void OnCollisionStay(Collision collision) { }

        public virtual void OnTriggerEnter(Collider other) { }

        public virtual void OnTriggerExit(Collider other) { }

        public virtual void OnTriggerStay(Collider other) { }
    }
}
