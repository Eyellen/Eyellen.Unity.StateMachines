using Eyellen.Unity.StateMachines.Hierarchical;
using System;

namespace Eyellen.Unity.StateMachines.Samples.Hierarchical
{
    public class PlayerStateMachine : StateMachine
    {
        private PlayerController _context;

        private StateFactory _stateFactory;
        protected override StateFactory StateFactory => _stateFactory;

        public PlayerStateMachine(Type initialState, PlayerController context)
            : base()
        {
            _context = context;
            _stateFactory = new PlayerStateFactory(this, _context);

            Initialize(initialState);
        }
    }
}
