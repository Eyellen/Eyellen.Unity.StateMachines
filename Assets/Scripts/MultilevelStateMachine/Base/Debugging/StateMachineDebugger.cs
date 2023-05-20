using System.Reflection;
using UnityEngine;

namespace StateMachines.Multilevel.Debugging
{
    public class StateMachineDebugger : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("This must be script that contains state machine.")]
        private MonoBehaviour _script;

        [SerializeField]
        private Rect _windowRect = new Rect(10, 10, 300, 400);

        private StateMachine _stateMachine;

        private void Start()
        {
            _stateMachine = GetStateMachine(_script);
        }

        private void OnGUI()
        {
            GUILayout.Window(0, _windowRect, (id) => ShowStateMachineInfo(), "State Machine Info");
        }

        private StateMachine GetStateMachine(MonoBehaviour script)
        {
            StateMachine stateMachine = null;
            bool isStateMachineFound = false;

            BindingFlags flags = (BindingFlags)(-1);

            FieldInfo[] fields = script.GetType().GetFields(flags);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(StateMachine)))
                {
                    stateMachine = (StateMachine)field.GetValue(script);
                    isStateMachineFound = true;
                    break;
                }
            }

            if (!isStateMachineFound)
                throw new StateMachineNotFoundException($"Script you provided does not contain StateMachine.");

            return stateMachine;
        }

        private void ShowStateMachineInfo()
        {
            if (_stateMachine == null)
                return;

            State state;

            FieldInfo field = typeof(StateMachine).GetField("_currentState", (BindingFlags)(-1));
            state = (State)field.GetValue(_stateMachine);

            GUILayout.BeginVertical();
            GUILayout.Label("States Hierarchy", GUILayout.ExpandWidth(true));

            field = typeof(State).GetField("_currentSubState", (BindingFlags)(-1));
            while (state != null)
            {
                GUILayout.Box(state.ToString(), GUILayout.ExpandWidth(true));

                state = (State)field.GetValue(state);
            }

            GUILayout.EndVertical();
        }
    }
}