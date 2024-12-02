using System;
using UnityEngine;

namespace StateMachine
{
    public class AbstractStateMachine : MonoBehaviour
    {
        [SerializeField] protected AbstractState _startState;
        
        private AbstractState _currentState;

        private void Awake()
        {
            _currentState = _startState;
        }

        private void Start()
        {
            _currentState.StartState();
        }

        private void Update()
        {
            if (_currentState == null) return;
            
            var nextState = _currentState.GetNextState();

            if (nextState != null) Transition(nextState);
        }

        private void Transition(AbstractState nextState)
        {
            if (_currentState != null) _currentState.ExitState();
            
            _currentState = nextState;
            
            _currentState.StartState();
        }
    }
}
