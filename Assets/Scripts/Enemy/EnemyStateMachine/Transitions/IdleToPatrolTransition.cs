using StateMachine;
using UnityEngine;

namespace Enemy.EnemyStateMachine.Transitions
{
    public class IdleToPatrolTransition : AbstractTransition
    {
        [SerializeField] private float _transitionDelay;
        
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _transitionDelay)
            {
                ShouldTransition = true;
                _timer = 0;
            }
        }
    }
}