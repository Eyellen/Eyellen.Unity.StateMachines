using UnityEngine;

namespace StateMachines.Multilevel.Example
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        private bool _debugging = false;
#endif

        private PlayerStateMachine _stateMachine;

        [field: HideInInspector]
        public Transform Transform { get; private set; }

        [field: HideInInspector]
        public CapsuleCollider CapsuleCollider { get; private set; }

        [field: HideInInspector]
        public Rigidbody Rigidbody { get; private set; }

        [field: HideInInspector]
        public PlayerInput Input { get; private set; }

        [SerializeField]
        private float _skinThickness = 0.01f;

        [SerializeField]
        [Tooltip("Offset for sphere area that checks if player is grounded.")]
        private float _groundedSphereOffset = 0.05f;

        [field: Header("Grounded states settings.")]
        [field: SerializeField]
        public float WalkSpeed { get; private set; } = 5f;

        [field: SerializeField]
        public float RunSpeed { get; private set; } = 10f;

        [field: Header("Jump state settings.")]
        [field: SerializeField]
        public float JumpStrength { get; private set; } = 5f;

        [field: Header("Midair states settings.")]
        [field: SerializeField]
        public float MidairMovementSpeed { get; private set; } = 0.1f;

        private int _isGroundedLayerMask;

        private void Awake()
        {
            _isGroundedLayerMask = ~(1 << LayerMask.NameToLayer("Player"));

            Transform = transform;
            CapsuleCollider = GetComponent<CapsuleCollider>();
            Rigidbody = GetComponent<Rigidbody>();
            Input = GetComponent<PlayerInput>();

            _stateMachine = new PlayerStateMachine(typeof(GroundedState), this);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public bool IsGrounded()
        {
            Vector3 position = Transform.position + (CapsuleCollider.center -
                Vector3.up * (CapsuleCollider.height / 2 - CapsuleCollider.radius + _groundedSphereOffset));

            return Physics.CheckSphere(position, CapsuleCollider.radius - _skinThickness, _isGroundedLayerMask);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!_debugging)
                return;

            if (Transform != null && CapsuleCollider != null)
            {
                Vector3 position = Transform.position + (CapsuleCollider.center -
                    Vector3.up * (CapsuleCollider.height / 2 - CapsuleCollider.radius + _groundedSphereOffset));

                Gizmos.DrawWireSphere(position, CapsuleCollider.radius - _skinThickness);
            }
        }
#endif
    }
}
