using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples
{
    [DisallowMultipleComponent]
    public class Character : MonoBehaviour
    {
        CharacterStateMachine _stateMachine;

        private State _currentState;

        [field: SerializeField]
        public Transform Transform { get; private set; }

        [field: SerializeField]
        public CapsuleCollider CapsuleCollider { get; private set; }

        [field: SerializeField]
        public Rigidbody Rigidbody { get; private set; }

        [field: SerializeField]
        public PlayerInput Input { get; private set; }

        [Header("Common")]
        [SerializeField]
        private float _skinThickness = 0.01f;

        [SerializeField]
        [Tooltip("Offset for sphere area that checks if player is grounded.")]
        private float _groundedSphereOffset = 0.05f;

        [field: Header("Grounded states settings")]
        [field: SerializeField]
        public float WalkSpeed { get; private set; } = 5f;

        [field: SerializeField]
        public float RunSpeed { get; private set; } = 10f;

        [field: Header("Jump state settings")]
        [field: SerializeField]
        public float JumpStrength { get; private set; } = 5f;

        [SerializeField]
        private LayerMask _groundLayer;

        private void Reset()
        {
            if (Transform == null)
            {
                Transform = GetComponent<Transform>();
            }

            if (CapsuleCollider == null)
            {
                CapsuleCollider = GetComponent<CapsuleCollider>();

                if (CapsuleCollider == null)
                    CapsuleCollider = gameObject.AddComponent<CapsuleCollider>();
            }

            if (Rigidbody == null)
            {
                Rigidbody = GetComponent<Rigidbody>();

                if (Rigidbody == null)
                    Rigidbody = gameObject.AddComponent<Rigidbody>();

                Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                Rigidbody.freezeRotation = true;
                Rigidbody.mass = 70f;
            }

            if (Input == null)
            {
                Input = GetComponent<PlayerInput>();

                if (Input == null)
                    Input = gameObject.AddComponent<PlayerInput>();
            }

            _groundLayer = ~0;
        }

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            CapsuleCollider = GetComponent<CapsuleCollider>();
            Rigidbody = GetComponent<Rigidbody>();
            Input = GetComponent<PlayerInput>();

            _stateMachine = new CharacterStateMachine(this);
            _stateMachine.OnStateChanged += (previous, current) => _currentState = current;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        public bool IsGrounded()
        {
            Vector3 position = Transform.position + (CapsuleCollider.center -
                Vector3.up * (CapsuleCollider.height / 2 - CapsuleCollider.radius + _groundedSphereOffset));

            return Physics.CheckSphere(position, CapsuleCollider.radius - _skinThickness, _groundLayer);
        }
    }
}
