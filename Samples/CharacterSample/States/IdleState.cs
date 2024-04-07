using UnityEngine;

namespace Eyellen.Unity.StateMachines.Samples
{
    public class IdleState : BaseState
    {
        public IdleState(CharacterStateMachine stateMachine, Character context) : base(stateMachine, context) { }

        public override void OnEnter()
        {
            _context.Rigidbody.velocity = new Vector3(0, _context.Rigidbody.velocity.y, 0);
        }
    }
}
