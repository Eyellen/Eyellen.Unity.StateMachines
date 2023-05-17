using System;

namespace StateMachines.Multilevel.Example
{
    public class PlayerStateMachine : StateMachine
    {
        private PlayerController _context;

        private StateFactory _stateFactory;
        protected override StateFactory StateFactory
        {
            get => _stateFactory;
        }

        public PlayerStateMachine(Type initialState, PlayerController context)
            : base()
        {
            _context = context;
            _stateFactory = new PlayerStateFactory(this, _context);

            Initialize(initialState);
        }
    }
}
