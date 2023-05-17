using UnityEngine;

namespace StateMachines.Multilevel.Example
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
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
        private float _groundedSphereOffset = 0.05f;

        [field: SerializeField]
        public float WalkSpeed { get; private set; } = 5f;

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

        private void OnDrawGizmos()
        {
            if (Transform != null && CapsuleCollider != null)
            {
                Vector3 position = Transform.position + (CapsuleCollider.center -
                Vector3.up * (CapsuleCollider.height / 2 - CapsuleCollider.radius + _groundedSphereOffset));

                Gizmos.DrawWireSphere(position, CapsuleCollider.radius - _skinThickness);
            }
        }
    }
}
