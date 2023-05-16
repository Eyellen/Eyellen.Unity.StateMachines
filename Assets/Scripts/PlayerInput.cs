using UnityEngine;

namespace StateMachines
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector3 MovementVector { get => new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized; }
    }
}
