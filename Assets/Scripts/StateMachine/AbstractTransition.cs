using UnityEngine;

namespace StateMachine
{
    public class AbstractTransition : MonoBehaviour
    {
        [SerializeField] private AbstractState _stateToTransition;
        
        public AbstractState StateToTransition => _stateToTransition;
        public bool ShouldTransition { get; set; }

        private void OnEnable()
        {
            ShouldTransition = false;
        }
    }
}
