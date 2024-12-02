using StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.EnemyStateMachine.States
{
    public class ChaseState : AbstractState
    {
        private GameObject _player;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        
        private readonly int _chaseStateHash = Animator.StringToHash("Run");

        private void Awake()
        {
            _player = GameObject.Find("Player");
        }

        public override void StartState()
        {
            _agent.speed = 8f;
            base.StartState();
        }

        private void Update()
        {
            _animator.CrossFade(_chaseStateHash, 0f);
            _agent.SetDestination(_player.transform.position);
        }
        
        public override void ExitState()
        {
            base.ExitState();
        }

        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 17f);
        }

    }
}