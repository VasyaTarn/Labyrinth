using StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.EnemyStateMachine.States
{
    public class PatrolState : AbstractState
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _patrolRadius;
        
        private readonly int _patrolStateHash = Animator.StringToHash("Walk");
        
        public override void StartState()
        {
            base.StartState();
            PatrolRandomPoint();
        }

        private void Update()
        {
            _animator.CrossFade(_patrolStateHash, 0f);
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        private void PatrolRandomPoint()
        {
            var randomPoint = GetRandomPointOnNavMeshSurface(_patrolRadius);
            
            _agent.SetDestination(randomPoint);
        }

        private Vector3 GetRandomPointOnNavMeshSurface(float radius)
        {
            var randomPoint = Random.insideUnitSphere * radius; 

            if (NavMesh.SamplePosition(randomPoint, out var hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }
            
            return Vector3.zero;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _patrolRadius);
        }
    }
}