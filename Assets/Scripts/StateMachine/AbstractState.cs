using UnityEngine;
using UnityEngine.Serialization;

namespace StateMachine
{
    public abstract class AbstractState : MonoBehaviour
    {
        [SerializeField] private AbstractTransition[] _transitions;

        public virtual void StartState()
        {
            if (!enabled)
            {
                enabled = true;

                foreach (var transition in _transitions)
                {
                    transition.enabled = true;
                }
            }
        }
        
        public virtual void ExitState()
        {
            if (enabled)
            {
                enabled = false;

                foreach (var transition in _transitions)
                {
                    transition.enabled = false;
                }
            }
        }

        public AbstractState GetNextState()
        {
            foreach (var transition in _transitions)
            {
                if (transition.ShouldTransition)
                {
                    return transition.StateToTransition;
                }
            }
            
            return null;
        }
    }
}
