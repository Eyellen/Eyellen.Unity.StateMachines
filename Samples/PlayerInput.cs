using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector3 MovementVector => new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        public bool IsJumpPressed => Input.GetKeyDown(KeyCode.Space);

        public bool IsSprinting => Input.GetKey(KeyCode.LeftShift);
    }
}
