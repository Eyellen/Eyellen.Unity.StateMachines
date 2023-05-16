using System.Collections.Generic;

namespace StateMachines.SingleLevel
{
    public abstract class State
    {
        private List<Transition> _transitions = new List<Transition>();

        public void AddTransition(Transition transition)
        {
            _transitions.Add(transition);
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update()
        {
            for (int i = 0; i < _transitions.Count; i++)
                _transitions[i].Update();
        }
    }
}
