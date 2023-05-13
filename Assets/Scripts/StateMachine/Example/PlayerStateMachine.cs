using UnityEngine;

namespace StateMachines.Example
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerStateMachine : StateMachine
    {
        [field: HideInInspector]
        public Transform Transform { get; private set; }

        [field: HideInInspector]
        public Rigidbody Rigidbody { get; private set; }

        [field: HideInInspector]
        public PlayerInput Input { get; private set; }

        [field: SerializeField]
        public float WalkSpeed { get; private set; } = 5f;

        private void Awake()
        {
            Transform = transform;
            Rigidbody = GetComponent<Rigidbody>();
            Input = GetComponent<PlayerInput>();

            State idle = new IdleState();
            State walk = new WalkState(this);

            Transition movementIsPressed = new MovementIsPressed(this, idle, walk);
            Transition movementIsNotPressed = new MovementIsNotPressed(this, walk, idle);

            Initialize(idle);
        }
    }
}
