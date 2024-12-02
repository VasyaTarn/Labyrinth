using StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.EnemyStateMachine.Transitions
{
    public class PatrolToIdleTransition : AbstractTransition
    {
        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            if (_agent.remainingDistance <= 0.1f)
                ShouldTransition = true;
        }
    }
}